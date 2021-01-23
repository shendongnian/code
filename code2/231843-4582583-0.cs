    interface IUntypedField { }
    class Field<TValue> : IUntypedField { }
    interface IFieldMap
    {
        void Put<TValue>(Field<TValue> field, TValue value);
        TValue Get<TValue>(Field<TValue> field);
        void PutObject(IUntypedField field, object value); // <-- this has a cast
                                                     // to TValue for type safety
        object GetObject(IUntypedField field);
    }
    class MapCopier
    {
        void Copy(IEnumerable<IUntypedField> fields, IFieldMap from, IFieldMap to)
        {
            foreach (var field in fields)
                Copy(field, from, to); // <-- now compiles because
                                       // it calls non-generic overload
        }
        // non-generic overload of Copy
        void Copy(IUntypedField field, IFieldMap from, IFieldMap to)
        {
            to.PutObject(field, from.GetObject(field));
        }
        void Copy<TValue>(Field<TValue> field, IFieldMap from, IFieldMap to)
        {
            to.Put(field, from.Get(field));
        }
    }
