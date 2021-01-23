    MyObject myObject = null;
   
    try
    {
        myObject = new MyObject();
        ...
    }
    finally
    {
        if (myObject != null)
        {
             myObject.Dispose();
        }
    }
   
