    #if DEBUG
        [PageUrl(DebugVariables.TEST_URL, Protocol = DebugVariables.HTTPS_PROTOCOL)]
    #else
        [PageUrl(ProductionVariables.TEST_URL, Protocol = ProductionVariables.HTTPS_PROTOCOL)]
    #endif
        public class LoginPage : AbstractPage
        {
        }
