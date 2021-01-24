public class GreatClass
    {
        private ICustomService _customService;
        public GreatClass(ICustomService customService)
        {
            _customService = customService;
        }
        [FunctionName("MyFunc")]
        public async Task Run([TimerTrigger("%RunFrequency%", RunOnStartup = true)]TimerInfo myTimer,
            // ICustomService customService, // Incorrect!
            ILogger log)
        {
            //Logic
        }
    }
