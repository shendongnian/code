    public class FormMultipartEncodedMediaTypeFormatter : MediaTypeFormatter
    {
        private const string SupportedMediaType = "multipart/form-data";
        public FormMultipartEncodedMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(SupportedMediaType));
        }
        // can we deserialize multipart/form-data to specific type
        public override bool CanReadType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return true;
        }
        // can we serialize specific type to multipart/form-data
        public override bool CanWriteType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return false;
        }
        // deserialization
        public override async Task<object> ReadFromStreamAsync(
            Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (readStream == null) throw new ArgumentNullException(nameof(readStream));
            try
            {
                // read content 
                var multipartProvider = await content.ReadAsMultipartAsync();
                // fill out model dictionary
                var modelDictionary = await ToModelDictionaryAsync(multipartProvider);
                // apply dictionary to model instance
                return BindToModel(modelDictionary, type, formatterLogger);
            }
            catch (Exception e)
            {
                if (formatterLogger == null) throw;
                formatterLogger.LogError(string.Empty, e);
                return GetDefaultValueForType(type);
            }
        }
        // fill out model dictionary
        private async Task<IDictionary<string, object>> ToModelDictionaryAsync(MultipartMemoryStreamProvider multipartProvider)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var element in multipartProvider.Contents)
            {
                // getting element name
                var name = element.Headers.ContentDisposition.Name.Trim('"');
                // if we have a FileName - this is a file
                // if not - pretend this is a string (later binder will transform this strings to objects)
                if (!string.IsNullOrEmpty(element.Headers.ContentDisposition.FileName))
                    // create our HttpPostedFileMultipart instance if we have any data
                    if (element.Headers.ContentLength.GetValueOrDefault() > 0)
                        dictionary[name] = new HttpPostedFileMultipart(
                            element.Headers.ContentDisposition.FileName.Trim('"'),
                            element.Headers.ContentType.MediaType,
                            await element.ReadAsByteArrayAsync()
                        );
                    else
                        dictionary[name] = null;
                else
                    dictionary[name] = await element.ReadAsStringAsync();
            }
            return dictionary;
        }
        // apply dictionary to model instance
        private object BindToModel(IDictionary<string, object> data, Type type, IFormatterLogger formatterLogger)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (type == null) throw new ArgumentNullException(nameof(type));
            using (var config = new HttpConfiguration())
            {
                if (RequiredMemberSelector != null && formatterLogger != null)
                    config.Services.Replace(
                        typeof(ModelValidatorProvider),
                        new RequiredMemberModelValidatorProvider(RequiredMemberSelector));
                var actionContext = new HttpActionContext {
                    ControllerContext = new HttpControllerContext {
                        Configuration = config,
                        ControllerDescriptor = new HttpControllerDescriptor { Configuration = config }
                    }
                };
                // workaround possible locale mismatch
                var cultureBugWorkaround = CultureInfo.CurrentCulture.Clone() as CultureInfo;
                cultureBugWorkaround.NumberFormat = CultureInfo.InvariantCulture.NumberFormat;
                var valueProvider = new NameValuePairsValueProvider(data, cultureBugWorkaround);
                var metadataProvider = actionContext.ControllerContext.Configuration.Services.GetModelMetadataProvider();
                var metadata = metadataProvider.GetMetadataForType(null, type);
                var modelBindingContext = new ModelBindingContext
                {
                    ModelName = string.Empty,
                    FallbackToEmptyPrefix = false,
                    ModelMetadata = metadata,
                    ModelState = actionContext.ModelState,
                    ValueProvider = valueProvider
                };
                // bind our model
                var modelBinderProvider = new CompositeModelBinderProvider(config.Services.GetModelBinderProviders());
                var binder = modelBinderProvider.GetBinder(config, type);
                var haveResult = binder.BindModel(actionContext, modelBindingContext);
                // store validation errors
                if (formatterLogger != null)
                    foreach (var modelStatePair in actionContext.ModelState)
                        foreach (var modelError in modelStatePair.Value.Errors)
                            if (modelError.Exception != null)
                                formatterLogger.LogError(modelStatePair.Key, modelError.Exception);
                            else
                                formatterLogger.LogError(modelStatePair.Key, modelError.ErrorMessage);
                return haveResult ? modelBindingContext.Model : GetDefaultValueForType(type);
            }
        }
    }
