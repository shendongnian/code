    public class WebJob
    {
      private readonly IOptions<WebJobSettings> _webJobSettings;
      public WebJob(
        IOptions<WebJobSettings> webJobSettings)
      {
        _webJobSettings = webJobSettings;
      } 
    }
