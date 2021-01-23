    public DataAccess 
    { 
        public static T GetInstance<T>() where T : new()
        { 
            return new T()
        } 
    }
