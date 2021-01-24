public class CustomSerializerSettingsSetup : IConfigureOptions<MvcOptions>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ArrayPool<char> _charPool;
    private readonly ObjectPoolProvider _objectPoolProvider;
    public CustomSerializerSettingsSetup(
        ILoggerFactory loggerFactory,
        ArrayPool<char> charPool,
        ObjectPoolProvider objectPoolProvider)
    {
        _loggerFactory = loggerFactory;
        _charPool = charPool;
        _objectPoolProvider = objectPoolProvider;
    }
    public void Configure(MvcOptions options)
    {
        options.OutputFormatters.RemoveType<JsonOutputFormatter>();
        options.InputFormatters.RemoveType<JsonInputFormatter>();
        options.InputFormatters.RemoveType<JsonPatchInputFormatter>();
        var outputSettings = new JsonSerializerSettings();
        options.OutputFormatters.Add(new JsonOutputFormatter(outputSettings, _charPool));
        var inputSettings = new JsonSerializerSettings();
        var jsonInputLogger = _loggerFactory.CreateLogger<JsonInputFormatter>();
        options.InputFormatters.Add(new JsonInputFormatter(
            jsonInputLogger,
            inputSettings,
            _charPool,
            _objectPoolProvider));
        var jsonInputPatchLogger = _loggerFactory.CreateLogger<JsonPatchInputFormatter>();
        options.InputFormatters.Add(new JsonPatchInputFormatter(
            jsonInputPatchLogger,
            inputSettings,
            _charPool,
            _objectPoolProvider));
    }
}
and
services.TryAddEnumerable(
    ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, CustomSerializerSettingsSetup>());
in service provider configuration
