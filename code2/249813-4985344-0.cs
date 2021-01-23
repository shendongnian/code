    public static class DBCreator
    {
       public static MyDataContext Create()
       {
           return new MyDataContext(ConfigurationManager.ConnectionStrings["ConnName"].ConnectionString);
        }
    }
