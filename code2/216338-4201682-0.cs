    public IList SomeMethod(Type t)
        { 
            Type listType = typeof(List<>);
            listType = listType.MakeGenericType(new Type[] { t});
            object list = Activator.CreateInstance(listType);
            return (IList)list;
        }
