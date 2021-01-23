    public static class Utils
    {
        public static string UserName(IDictionary<object,dynamic> pageData) {
            return pageData["UserName"] as string;
        }
    }
