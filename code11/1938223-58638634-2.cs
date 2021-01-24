    [ApiController]
    public class BotController : SkillController
    {
      public BotController(IServiceProvider serviceProvider, BotSettingsBase botSettings)
    	  : base(serviceProvider, botSettings)
      { }
    }
