    // partially borrowed from
    // https://thomaslevesque.com/2018/09/04/handling-multipart-requests-with-json-and-file-uploads-in-asp-net-core/
    public class JsonWithFilesFormDataModelBinder : IModelBinder
    {
        // code from FormFileModelBuilder
        private class FileCollection : ReadOnlyCollection<IFormFile>, IFormFileCollection
        {
            public FileCollection(List<IFormFile> list)
                : base(list)
            {
            }
            public IFormFile this[string name] => GetFile(name);
            public IFormFile GetFile(string name)
            {
                for (var i = 0; i < Items.Count; i++)
                {
                    var file = Items[i];
                    if (string.Equals(name, file.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return file;
                    }
                }
                return null;
            }
            public IReadOnlyList<IFormFile> GetFiles(string name)
            {
                var files = new List<IFormFile>();
                for (var i = 0; i < Items.Count; i++)
                {
                    var file = Items[i];
                    if (string.Equals(name, file.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        files.Add(file);
                    }
                }
                return files;
            }
        }
        private readonly IOptions<MvcJsonOptions> _jsonOptions;
        const string JSON_PART_FIELD_NAME = "json";
        public JsonWithFilesFormDataModelBinder(IOptions<MvcJsonOptions> jsonOptions)
        {
            _jsonOptions = jsonOptions;
        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var request = bindingContext.HttpContext.Request;
            if (!request.HasFormContentType)
                return;
            // Retrieve the form part containing the JSON
            var valueResult = bindingContext.ValueProvider.GetValue(JSON_PART_FIELD_NAME);
            if (valueResult == ValueProviderResult.None)
            {
                // The JSON was not found
                var message = bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(bindingContext.FieldName);
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
                return;
            }
 
            var rawValue = valueResult.FirstValue;
 
            // Deserialize the JSON
            var model = JsonConvert.DeserializeObject(rawValue, bindingContext.ModelType, _jsonOptions.Value.SerializerSettings);
            if (model == null)
            {
                bindingContext.Result = ModelBindingResult.Success(model);
                return; // nothing to do
            }
            // could not use FormFileModelBinder because don't know how to recurse into collections
            // doing it manually from request instead
            // collecting all file fields
            // code from FormFileModelBinder
            var form = await request.ReadFormAsync();
            ICollection<IFormFile> postedFiles = new List<IFormFile>();
            foreach (var file in form.Files)
            {
                // If there is an <input type="file" ... /> in the form and is left blank.
                if (file.Length == 0 || string.IsNullOrEmpty(file.FileName))
                {
                    continue;
                }
                postedFiles.Add(file);
            }
            // now recursively step through the deserialized model
            // and fill all the recognized IFormFile and IFormFileCollection fields
            TryAssignFormFiles(model, postedFiles);
            // Set the successfully constructed model as the result of the model binding
            bindingContext.Result = ModelBindingResult.Success(model);
        }
        private void TryAssignFormFiles(object model, ICollection<IFormFile> postedFiles, string path = "")
        {
            // fill all the recognized IFormFile and IFormFileCollection fields
            var props = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in props)
            {
                var pt = property.PropertyType;
                var formFieldPath = path + property.Name;
                var matchingFiles = postedFiles.Where(p => p.Name.Equals(formFieldPath,
                    StringComparison.OrdinalIgnoreCase));
                if (typeof(IFormFile).IsAssignableFrom(pt))
                {
                    if (matchingFiles.Count() != 1)
                    {
                        // ambiguous, cannot process more or zero files for single item
                        continue;
                    }
                    property.SetValue(model, matchingFiles.First());
                    continue;
                }
                else if (typeof(IFormFile[]).IsAssignableFrom(pt))
                {
                    if (matchingFiles.Count() > 0)
                        property.SetValue(model, matchingFiles.ToArray());
                    continue;
                }
                else if (typeof(IList<IFormFile>).IsAssignableFrom(pt))
                {
                    if (matchingFiles.Count() > 0)
                        property.SetValue(model, matchingFiles.ToList());
                    continue;
                }
                else if (typeof(IFormFileCollection).IsAssignableFrom(pt))
                {
                    if (matchingFiles.Count() > 0)
                        property.SetValue(model, new FileCollection(matchingFiles.ToList()));
                    continue;
                }
                // if got here, then field was not a file or a collection of files
                // attempt to recurse deeper
                // is this enumerable? ignore strings that are enumerable chars
                if (!typeof(string).IsAssignableFrom(pt) &&
                    typeof(IEnumerable).IsAssignableFrom(pt))
                {
                    if (!(property.GetValue(model) is IEnumerable ienum))
                        continue;
                    int seq = 0;
                    foreach (var ev in ienum)
                    {
                        TryAssignFormFiles(ev, postedFiles, path + $"{property.Name}[{seq}].");
                        seq++;
                    }
                }
                else // not a collection
                     // ignore primitives and nullable primitives
                if (Nullable.GetUnderlyingType(pt) == null &&
                    !pt.IsValueType && !pt.IsEnum)
                {
                    // some class-like thing, recurse into it
                    // TODO: what about dictionaries that are struct KeyValuePair<TKey, TValue>?
                    // for now, assuming we won't be receiving those in our JSON
                    // because usually dictionary-like objects should be mapped to .NET class properties instead
                    var val = property.GetValue(model);
                    if (val == null)
                        continue;
                    TryAssignFormFiles(val, postedFiles, path + $"{property.Name}.");
                }
            }
        }
    }
Testing data structures: 
    public class RootModel
    {
        public string SomeField { get; set; }
        public IList<ChildModel> FilesWithDescriptions { get; set; }
        public IFormFile MainFile { get; set; }
        public IFormFile SomeOtherFile { get; set; }
    }
    public class ChildModel
    {
        public string FileDescription { get; set; }
        public IFormFileCollection SomeNestedFiles { get; set; }
        public IFormFile SomeNestedFile { get; set; }
        public IFormFile[] SomeNestedFilesArray { get; set; }
        public IList<IFormFile> SomeNestedFilesList { get; set; }
    }
Test controller method:
        public async Task<ActionResult> AcceptJsonMultipart([ModelBinder(typeof(JsonWithFilesFormDataModelBinder))]RootModel model)
          
Postman setup:
[![Postman setup for multipart JSON with nested files][1]][1]
  [1]: https://i.stack.imgur.com/tSSbt.png
JSON field in Postman:
{       
    "someField":"hello",
    "filesWithDescriptions":[
        {
            "fileDescription":"a file"
        },
        {
            "fileDescription":"b file"
        }
    ]
}
In general, it works, although it sacrifices .NET ModelBinder mechanisms (custom field names, validators etc.). If anybody knows a better way, you are very welcome to suggest something less hacky.
