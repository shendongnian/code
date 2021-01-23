    public static class Test
    {
        public object CreateInstance(string typeName)
        { 
            Type type = Type.GetType(typeName);
            return Activator.CreateInstance(type);
        }
    }
