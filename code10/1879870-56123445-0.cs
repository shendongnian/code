    public class ActionBar_Setup : Android.Support.V4.App.Fragment
     {
   
        public static ActionBar_Setup Instance;
        public static ActionBar_Setup NewInstance()
        {
            if (Instance== null)
            {
                Instance= new ActionBar_Setup();
            }
            return Instance;
        }
        ...
    }
