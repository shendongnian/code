    public static class Page {
        private static <T> T GetPage(Class<T> page) {
            return PageFactory.InitElements(BrowserFactory.Driver, page);       
        }
        public static HomePage getHomePage() {
            return Page.GetPage(HomePage.class);
        }
    }
