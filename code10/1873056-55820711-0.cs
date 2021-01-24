    public static class ObjectFactory
    {
        public static T GetObject<T>() where T : new()
        {
            return new T();
        }
        public static User GetUserObject(param1, param2)
        {
            // some logic
            ....
            return new User();
        }
    }
