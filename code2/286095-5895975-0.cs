    protected MyObjectType MyObject;
    protected void BindRepeater(IEnumerable someDataSource)
    {
        using(MyObject = SomeClass.SomeMethodToGetObject())
        {
            myRepeater.DataSource = someDataSource;
            myRepeater.DataBind();
        }
    }
