csharp
// the custom attribute
internal abstract class UseJsonAttribute : Attribute, IAsyncActionFilter
{
    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) => next();
}
internal class UseSystemTextJsonAttribute : UseJsonAttribute { }
internal class UseNewtonsoftJsonAttribute : UseJsonAttribute { }
// Our Super Input Formatter
internal class MySuperJsonInputFormatter : TextInputFormatter
{
    public MySuperJsonInputFormatter()
    {
        SupportedEncodings.Add(UTF8EncodingWithoutBOM);
        SupportedEncodings.Add(UTF16EncodingLittleEndian);
        SupportedMediaTypes.Add("application/json");
    }
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    {
        var mvcOpt= context.HttpContext.RequestServices.GetRequiredService<IOptions<MvcOptions>>().Value;
        var formatters = mvcOpt.InputFormatters;
        TextInputFormatter formatter =null; // the real formatter : SystemTextJsonInput or Newtonsoft
        Endpoint endpoint = context.HttpContext.GetEndpoint();
        if(endpoint.Metadata.GetMetadata<UseSystemTextJsonAttribute>()!= null)
        {
            formatter= formatters.OfType<SystemTextJsonInputFormatter>().FirstOrDefault();
            //formatter = formatter ?? SystemTextJsonInputFormatter
        }
        else if( endpoint.Metadata.GetMetadata<UseNewtonsoftJsonAttribute>() != null){
            // don't use `Of<NewtonsoftJsonInputFormatter>` here because there's a NewtonsoftJsonPatchInputFormatter
            formatter= (NewtonsoftJsonInputFormatter)(formatters
                .Where(f =>typeof(NewtonsoftJsonInputFormatter) == f.GetType())
                .FirstOrDefault());
        }
        else{
            throw new Exception("This formatter is only used for System.Text.Json InputFormatter or NewtonsoftJson InputFormatter");
        }
        var result = await formatter.ReadRequestBodyAsync(context,encoding);
        return result;
    }
}
internal class MySuperJsonOutputFormatter : TextOutputFormatter
{
    ... // similar to MySuperJsonInputFormatter, omitted for brevity 
}
And then configure the Json settings/options in the startup:
csharp
services.AddControllers(opts =>{ })
    .AddNewtonsoftJson(opts =>{ /**/ })
    .AddJsonOptions(opts =>{ /**/ });
Note `AddNewtonsoftJson()` will remove the builtin `SystemTextJsonInputFormatters`. So we need configure the `MvcOptions` manually :
csharp
services.AddOptions<MvcOptions>()
    .PostConfigure<IOptions<JsonOptions>, IOptions<MvcNewtonsoftJsonOptions>,ArrayPool<char>, ObjectPoolProvider,ILoggerFactory>((opts, jsonOpts, newtonJsonOpts, charPool, objectPoolProvider, loggerFactory )=>{
        // configure System.Text.Json formatters
        if(opts.InputFormatters.OfType<SystemTextJsonInputFormatter>().Count() ==0){
            var systemInputlogger = loggerFactory.CreateLogger<SystemTextJsonInputFormatter>();
            opts.InputFormatters.Add(new SystemTextJsonInputFormatter(jsonOpts.Value, systemInputlogger));
        }
        if(opts.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().Count() ==0){
            opts.OutputFormatters.Add(new SystemTextJsonOutputFormatter(jsonOpts.Value.JsonSerializerOptions));
        }
        // configure Newtonjson formatters
        if(opts.InputFormatters.OfType<NewtonsoftJsonInputFormatter>().Count() ==0){
            var inputLogger= loggerFactory.CreateLogger<NewtonsoftJsonInputFormatter>();
            opts.InputFormatters.Add(new NewtonsoftJsonInputFormatter(
                inputLogger, newtonJsonOpts.Value.SerializerSettings, charPool, objectPoolProvider, opts, newtonJsonOpts.Value
            )); 
        }
        if(opts.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>().Count()==0){
            opts.OutputFormatters.Add(new NewtonsoftJsonOutputFormatter(newtonJsonOpts.Value.SerializerSettings, charPool, opts));
        }
        opts.InputFormatters.Insert(0, new MySuperJsonInputFormatter());
        opts.OutputFormatters.Insert(0, new MySuperJsonOutputFormatter());
    });
Now it should work fine.
