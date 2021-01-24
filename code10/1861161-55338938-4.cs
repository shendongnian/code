    public class MonobehaviourWrapper
    {
        private IMonobehaviourField<object>[] monobehaviourFields;
        public MonobehaviourWrapper(FieldInfo[] fields)
        {
            monobehaviourFields = new IMonobehaviourField<object>[fields.Length];
            for ( int i = 0; i < monobehaviourFields.Length; i++ )
            {
                Type fieldType = fields[i].FieldType;
                var constructedGenericType = typeof(MonobehaviourField<>).MakeGenericType(fieldType);
                var constructor = constructedGenericType.GetConstructor(new Type[] { fieldType });
                object resultOfConstructor = constructor.Invoke(new object[] { "test" });
                monobehaviourFields[i] = (IMonobehaviourField<object>)resultOfConstructor;
            }
        }
        public class MonobehaviourField<T> : IMonobehaviourField<T>
        {
            private string fieldName;
            public MonobehaviourField(string name)
            {
                FieldName = name;
            }
            public string FieldName
            {
                get { return fieldName; }
                set { fieldName = value; }
            }
        }
    }
