    public class MyDynamic: DynamicObject
    {
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();
        public MyDynamic(object initialData)
        {
            if (initialData == null) throw new ArgumentNullException("initialData");
            var type = initialData.GetType();
            foreach (var propertyInfo in type.GetProperties())
            {
                dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(initialData, null));
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            dictionary.TryGetValue(binder.Name, out result);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }
    }
