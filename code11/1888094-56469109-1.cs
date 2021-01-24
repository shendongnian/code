    public class PropDictionary<TDataObject> : IPropertyDictionary<TDataObject>
        where TDataObject : IProperties
    {
        public void AddIfSameType<TProperty>(
            Expression<Func<TDataObject, TProperty>> getProp, TProperty value)
        {
        }
    }
