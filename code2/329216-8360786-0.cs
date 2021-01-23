    public class AliasToDTOTransformer<D> : IResultTransformer where D: class, new()
    {
        private readonly IDictionary<Type, Func<object, object>> _converters;
        public AliasToDTOTransformer()
        {
            _converters = new Dictionary<Type, Func<object, object>>();
        }
        
        public void AddConverter<S,R>(Func<S,R> converter)
        {
            _converters[typeof (S)] = s => (object) converter((S) s);
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            var dto = new D();
            for (var i=0; i < aliases.Length; i++)
            {
                var propinfo = dto.GetType().GetProperty(aliases[i]);
                if (propinfo == null) continue;
                var valueToSet = ConvertValue(propinfo.PropertyType, tuple[i]);
                propinfo.SetValue(dto, valueToSet, null);
            }
            return dto;
        }
        private object ConvertValue(Type destinationType, object val)
        {
            //Try to approximate default(T) here
            if (val == null)
                return destinationType.IsValueType ? Activator.CreateInstance(destinationType) : null;
            var valType = val.GetType();
            if (_converters.ContainsKey(valType))
            {
                var func = _converters[valType];
                return  Convert.ChangeType(func.Invoke(val), destinationType);
            }
            if (destinationType.IsAssignableFrom(valType))
                return val;
                
            return Convert.ToString(val); // I dunno... maybe throw an exception here instead?
        }
        public IList TransformList(IList collection)
        {
            return collection;
        }
