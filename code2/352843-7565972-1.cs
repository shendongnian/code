    [WebMethod(MessageName = "MyMethodDefault")]
    public void MyMethod(int a, int b)
    {
          MyMethod( a, b, -3);
    }
    
    [WebMethod(MessageName = "MyMethod")]
    public void MyMethod(int a, int b, int c)
