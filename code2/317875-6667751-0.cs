    interface ISomeClass
    {
        bool IsActive {get;}
    }
    
    public abstract SomeClass<T> : ISomeClass where T : SomeInterface
    {
        public bool DoSomethingsWithT(T theItem)
        {
            //doStuff!!!
        }
    
        public virtual bool IsActive
        {
           get { return true; }  
        }
    }
    
    public bool SomeMethod(object item)
    {
        var something = item as ISomeClass;
    
        return something.IsActive;
    }
