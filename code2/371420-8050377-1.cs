    [Test...]
    public void MyTest()
    {
        using (NewContext(...))
        {
            // perform test here
        }
    }
    
    private static NewContext(...)
    {
        var list = new DisposableList();
    
        // add anything here
    
        return list;
    }
