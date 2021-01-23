    static class ContextFactory
    {
        public static MyDataContext CreateMyDataContent(string sitename)
        {
            var context;
            switch(sitename){
            case "first":
                context = new MyDataContext ("connection string");
            case "second":
                // and so on
            }
            return context;
        }
    }
