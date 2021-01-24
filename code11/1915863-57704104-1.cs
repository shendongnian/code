    public class WebJob
    {
    	private readonly IOptions<WebJobSettings> _webJobSettings;
    	private readonly IOptions<QueueSettings> _queueSettings;
    	private readonly IOptions<AssetSettings> _assetSettings;
    
    	public WebJob(
    		IOptions<WebJobSettings> webJobSettings,
    		IOptions<QueueSettings> queueSettings,
    		IOptions<AssetSettings> assetSettings)
    	{
    		_webJobSettings = webJobSettings;
    		_queueSettings = queueSettings;
    		_assetSettings = assetSettings;
    	}
