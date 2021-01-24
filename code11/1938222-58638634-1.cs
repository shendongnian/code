    public class MySkillAdapter : SkillAdapter
    {
    	public MySkillAdapter(
    		BotSettings settings,
    		ICredentialProvider credentialProvider,
    		BotStateSet botStateSet,
    		ResponseManager responseManager,
    		IBotTelemetryClient telemetryClient,
    		UserState userState) : base(credentialProvider)
    	{
    		//
    		Use(new SkillMiddleware(userState));
    	}
    }
