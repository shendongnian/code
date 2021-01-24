csharp
public class CustomJsonInputFormatter : JsonInputFormatter
{
    private readonly IArrayPool<char> charPool;
    private readonly MvcOptions options;
    public CustomJsonInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider, MvcOptions options, MvcJsonOptions jsonOptions)
        : base(logger, serializerSettings, charPool, objectPoolProvider, options, jsonOptions)
    {
        this.charPool = new JsonArrayPool<char>(charPool);
        this.options = options;
    }
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context,
        Encoding encoding)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        if (encoding == null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }
        var request = context.HttpContext.Request;
        var suppressInputFormatterBuffering = options?.SuppressInputFormatterBuffering ?? false;
        if (!request.Body.CanSeek && !suppressInputFormatterBuffering)
        {
            // JSON.Net does synchronous reads. In order to avoid blocking on the stream, we asynchronously
            // read everything into a buffer, and then seek back to the beginning.
            request.EnableBuffering();
            Debug.Assert(request.Body.CanSeek);
            await request.Body.DrainAsync(CancellationToken.None);
            request.Body.Seek(0L, SeekOrigin.Begin);
        }
        using (var streamReader = context.ReaderFactory(request.Body, encoding))
        {
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                jsonReader.ArrayPool = charPool;
                jsonReader.CloseInput = false;
                var successful = true;
                Exception exception = null;
                void ErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs eventArgs)
                {
                    successful = false;
                    var path = eventArgs.ErrorContext.Path;
                    var key = ModelNames.CreatePropertyModelName(context.ModelName, path);
                    context.ModelState.TryAddModelError(key, $"Invalid value specified for {path}");
                    eventArgs.ErrorContext.Handled = true;
                }
                var type = context.ModelType;
                var jsonSerializer = CreateJsonSerializer();
                jsonSerializer.Error += ErrorHandler;
                object model;
                try
                {
                    model = jsonSerializer.Deserialize(jsonReader, type);
                }
                finally
                {
                    // Clean up the error handler since CreateJsonSerializer() pools instances.
                    jsonSerializer.Error -= ErrorHandler;
                    ReleaseJsonSerializer(jsonSerializer);
                }
                if (successful)
                {
                    if (model == null && !context.TreatEmptyInputAsDefaultValue)
                    {
                        // Some nonempty inputs might deserialize as null, for example whitespace,
                        // or the JSON-encoded value "null". The upstream BodyModelBinder needs to
                        // be notified that we don't regard this as a real input so it can register
                        // a model binding error.
                        return InputFormatterResult.NoValue();
                    }
                    else
                    {
                        return InputFormatterResult.Success(model);
                    }
                }
                if (!(exception is JsonException || exception is OverflowException))
                {
                    var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
                    exceptionDispatchInfo.Throw();
                }
                return InputFormatterResult.Failure();
            }
        }
    }
}
Option 2: Perform pattern matching in [`InvalidModelStateResponseFactory`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apibehavioroptions.invalidmodelstateresponsefactory?view=aspnetcore-2.2) and replace the error
>Unexpected character encountered while parsing value: T. Path 'parent.booleanChild', line 0, position 0
Option 3: Set [`AllowInputFormatterExceptionMessages`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.mvcjsonoptions.allowinputformatterexceptionmessages?view=aspnetcore-2.2) to false and make the assumption in the [`InvalidModelStateResponseFactory`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apibehavioroptions.invalidmodelstateresponsefactory?view=aspnetcore-2.2) that any blank messages will be due to serialization errors.
I am not marking this as *the* answer as I am sure somebody else will have a better idea.
