    public class PropertyHolder<T, Y>
    {
        private static object[] emptyArray = new object[0];
        public PropertyHolder(Y instance, string propertyName)
        {
            var property = typeof(Y).GetProperty(propertyName);
            var setMethod = property.SetMethod;
            var getMethod = property.GetMethod;
            Set = (t) => setMethod.Invoke(instance, new object[]{t});
            Get = () => (T) getMethod.Invoke(instance, emptyArray);
        }
        
        public Action<T> Set { get; private set; }        
        public Func<T> Get { get; private set; }        
    }
