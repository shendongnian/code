    /// <summary>
    /// json.net serializes ALL properties of a class by default
    /// this class will tell json.net to only serialize properties if they MATCH 
    /// the list of valid columns passed through the querystring to criteria object
    /// </summary>
    public class CriteriaContractResolver<T> : DefaultContractResolver
    {
        List<string> _properties;
    
        public CriteriaContractResolver(List<string> properties)
        {
            _properties = properties
        }
    
        protected override IList<JsonProperty> CreateProperties(
            JsonObjectContract contract)
        {
            IList<JsonProperty> filtered = new List<JsonProperty>();
    
            foreach (JsonProperty p in base.CreateProperties(contract))
                if(_properties.Contains(p.PropertyName)) 
                    filtered.Add(p);
            
            return filtered;
        }
    }
