    public class MonobehaviourWrapper
    {
        private MonobehaviourFieldBase[] monobehaviourFields;
        public MonobehaviourWrapper(FieldInfo[] fields)
        {
            monobehaviourFields = new MonobehaviourFieldBase[fields.Length];
            for ( int i = 0; i < monobehaviourFields.Length; i++ )
            {
                Type fieldType = fields[i].FieldType;
                var constructedGenericType = typeof(MonobehaviourField<>).MakeGenericType(fieldType);
                var constructor = constructedGenericType.GetConstructor(new Type[] { typeof(string) });
                object resultOfConstructor = constructor.Invoke(new object[] { "This code has worked" });
                monobehaviourFields[i] = (MonobehaviourFieldBase)resultOfConstructor;
            }
        }
        public IEnumerable<MonobehaviourFieldBase> MonobehaviourFields
        {
            get
            {
                return monobehaviourFields;
            }
        }
        public class MonobehaviourField<T> : MonobehaviourFieldBase
        {
            public MonobehaviourField(string name)
            {
                FieldName = name;
            }
        }
    }
