    public interface IProperties
    {
        int IntProperty { get; set; }
        double DoubleProperty { get; set; }
        string StringProperty { get; set; }
    }
    public interface IPropertyDictionary<TDataObject> where TDataObject : IProperties
    {
        void AddIfSameType<TProperty>(
            Expression<Func<TDataObject, TProperty>> getProp, TProperty value);
    }
