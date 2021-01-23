    public MyObject[] Create()
    {
        //create class objects here and return them
        return new[] {new MyObject(), new MyObject()};
    }
    //later
    public void Use()
    {  
        MyObject[] objs = Create();
        //use your objects as you like
    }
