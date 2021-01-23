    public class NonFriendClass
    {
        public void DoSomething()
        {
             MainClass.FriendOnly(new FriendClass());
        }
    }
