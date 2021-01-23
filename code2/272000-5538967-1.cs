    public class BasePage : Page
    {
        public WebSessionHolder WebSession { get; set; }
        public BasePage()
        {
            WebSession = new WebSessionHolder(); // Or inject if you are using it.
        }
    }
