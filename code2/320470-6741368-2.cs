    public MyClass DeepCopy()
    {
        MyClass copy = new MyClass();
    
        copy.List = new List<string>(m_List);//deep copy each member, new list object is created
        
        return copy;
    }
