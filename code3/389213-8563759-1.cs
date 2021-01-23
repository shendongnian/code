    public List<Type> GetInterfaces(MasrhalByRefObject proxy)
    {
       List<Type> types = new List<Type>();
       IDescriptor des = proxy as IDescriptor;
       if (des != null)
       {
          foreach(string t in des.GetInterfaces()) // this is a remote call
          {
             types.Add(Type.GetType(t);
          }
       }
       return types;
    }
