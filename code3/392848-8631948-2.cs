    public A (A copyMe) {
        Type t = copyMe.GetType();
        foreach (FieldInfo fieldInf in t.GetFields())
        {
            fieldInf.SetValue(this, fieldInf.GetValue(copyMe));
        }
        foreach (PropertyInfo propInf in t.GetProperties())
        {
            propInf.SetValue(this, propInf.GetValue(copyMe));
        }
    }
