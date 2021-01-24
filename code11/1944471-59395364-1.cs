    [Binding]
    public class YourSteps
    {
        private readonly IWebDriver _webDriver;
        public CanvasSteps(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
