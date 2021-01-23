    public class FriendClass
    {
         public void DoSomethingInMain()
         {
             MainClass.FriendOnly(this);
         }
    }
    public class MainClass
    {
        public static void FriendOnly(object Caller)
        {
            if (!(Caller is FriendClass) /* Throw exception or return */;
            
            // Code
        }
    }
