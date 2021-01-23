    public class AliasToDTOTransformer<D> : IResultTransformer where D: class, new()
    {
        //Keep a dictionary of converts from Source -> Dest types...
        private readonly IDictionary<Tuple<Type, Type>, Func<object, object>> _converters;
        
        public AliasToDTOTransformer()
        {
            _converters = _converters = new Dictionary<Tuple<Type, Type>, Func<object, object>>();
        }
        
        public void AddConverter<S,R>(Func<S,R> converter)
        {
             _converters[new Tuple<Type, Type>(typeof (S), typeof (R))] = s => (object) converter((S) s);
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            var dto = new D();
            for (var i = 0; i < aliases.Length; i++)
            {
                var propinfo = dto.GetType().GetProperty(aliases[i]);
                if (propinfo == null) continue;
                var valueToSet = ConvertValue(propinfo.PropertyType, tuple[i]);
                propinfo.SetValue(dto, valueToSet, null);
            }
            return dto;
        }
        private object ConvertValue(Type destinationType, object sourceValue)
        {
            //Approximate default(T) here
            if (sourceValue == null)
                return destinationType.IsValueType ? Activator.CreateInstance(destinationType) : null;
            var sourceType = sourceValue.GetType();
            var tuple = new Tuple<Type, Type>(sourceType, destinationType);
            if (_converters.ContainsKey(tuple))
            {
                var func = _converters[tuple];
                return Convert.ChangeType(func.Invoke(sourceValue), destinationType);
            }
            if (destinationType.IsAssignableFrom(sourceType))
                return sourceValue;
            return Convert.ToString(sourceValue); // I dunno... maybe throw an exception here instead?
        }
        public IList TransformList(IList collection)
        {
            return collection;
        }
