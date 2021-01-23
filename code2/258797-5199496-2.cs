    void Put(object value)
    {
        if (value != null)
        {
            System.Nullable<Myenum> val = (System.Nullable<MyEnum>)(MyEnum)value;
        }
    }
