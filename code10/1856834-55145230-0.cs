    public class Users
    {
        public class TestConsumer
        {
            public string id { get; }
        }
    }
    public class Uri
    {
       private Users.TestConsumer testConsumer;
       //you are missing this declaration
       private Context context;
       public Uri(Context context)
       {
         this.context = context; <----- here if you try to assign context to Context class, it will give error and ask for a reference
         testConsumer = new Users.TestConsumer();
       }
    }
