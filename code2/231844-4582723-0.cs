    interface IUntypedField { }
    
    abstract class Field
    {
        protected Field(Type type)
        {
            FieldType = type;
        }
        public Type FieldType { get; private set; }
    }
    class Field<TValue> : Field, IUntypedField {
        public Field()
            : base(typeof(TValue))
        {
        }
    }
    interface IFieldMap
    {
        void Put(Field field, object value);
        object Get(Field field);
    }
    class MapCopier
    {
        void Copy(IEnumerable<IUntypedField> fields, IFieldMap from, IFieldMap to)
        {
            foreach (var field in fields)
            {
                Field f = field as Field;
                if (f != null)
                {
                    Copy(f, from, to);
                }
            }
        }
        void Copy(Field field, IFieldMap from, IFieldMap to)
        {
            to.Put(field, from.Get(field));
        }
    }
