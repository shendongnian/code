    public static MyProperty GetTitleText(MyContainer obj)
    {
        return (MyProperty)obj.GetValue(MyAttachedProperty);
    }
    public static void SetTitleText(MyContainer obj, MyProperty value)
    {
        obj.SetValue(MyAttachedProperty, value);
    }
