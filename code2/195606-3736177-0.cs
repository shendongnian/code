    public class InstanceRepository
    {
        private IDictionary<Type, ICollection> _Instances = new Dictionary<Type, ICollection>();
        public ICollection SomeTypeData(Type type)
        {
            ICollection instanceList;
            if (!_Instances.TryGetValue(type, out instanceList))
            {
                // this type does not exist in our dictionary, so let's create a new empty list
                // we could do this:
                //instanceList = new List<object>();
                // but let's use reflection to make a more type-specific List<T> instance:
                instanceList = (ICollection)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                // now add it to the dictionary
                _Instances.Add(type, instanceList);
            }
            // Return the collection, for this type.
            return instanceList;
        }
        public IList<T> SomeTypeData<T>()
        {
            Type type = typeof(T);
            ICollection instanceList;
            if (!_Instances.TryGetValue(typeof(T), out instanceList))
            {
                instanceList = new List<T>();
                _Instances.Add(type, instanceList);
            }
            // here we are assuming that all of the lists in our dictionary implement IList<T>.
            // This is a pretty safe assumption, since the dictionary is private and we know that
            // this class always creates List<T> objects to put into the dictionary.
            return (IList<T>)instanceList;
        }
    }
