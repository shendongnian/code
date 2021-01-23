    class PropertyDescriptor
    {
        public Type ModelType { get; set; }
        public string Property { get; set; }
    }
    
    class DependencyManager
    {
        private Dictionary<PropertyDescriptor, List<PropertyDescriptor>> _dependencies = new Dictionary<PropertyDescriptor, List<PropertyDescriptor>>();
    
        public void RegisterDependency(PropertyDescriptor property, PropertyDescriptor dependentProperty)
        {
            if (!_dependencies.ContainsKey(property))
            {
                _dependencies.Add(property, new List<PropertyDescriptor>());
            }
            _dependencies[property].Add(dependentProperty);
        }
        public IEnumerable<PropertyDescriptor> GetDependentProperties(PropertyDescriptor property)
        {
            if (!_dependencies.ContainsKey(property))
            {
                yield break;
            }
            else
            {
                foreach (PropertyDescriptor p in _dependencies[property])
                {
                    yield return p;
                }
             }
         }
    }
