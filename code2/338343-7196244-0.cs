    private MyProperty property;
    public MyProperty Property
    {
        get { return property; }
        set { property.SubPubValue(value, property_Changed); }
    }
    private static void property_Changed(object sender, PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
    public static class Extensions
    {
        public static void SubPubValue<T>(this T value, T setValue, PropertyChangedEventHandler property_Changed) where T : MyProperty
        {
            if (setValue != null)
                value.PropertyChanged -= property_Changed;
            value = setValue;
            if (setValue != null)
                value.PropertyChanged += property_Changed;
        }
    }
