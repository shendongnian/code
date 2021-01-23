    [WebMethod(MessageName = "MyMethod1")]
    public void MyMethod(int a, int b)
    {
        return MyMethod(a, b, -3);
    }
    [WebMethod(MessageName = "MyMethod2")]
    public void MyMethod(int a, int b, int c)
    {
    }
