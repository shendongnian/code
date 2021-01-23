       /// <summary>
        /// json.net serializes ALL properties of a class by default
        /// this class will tell json.net to only serialize properties if
        /// they MATCH the list of valid columns passed through the querystring to criteria object
        /// </summary>
        public class CriteriaContractResolver<T> : DefaultContractResolver
        {
            IRestCriteria<T> criteria;
    
            public CriteriaContractResolver(IRestCriteria<T> criteria)
            {
                this.criteria = criteria;
            }
    
            protected override IList<JsonProperty> CreateProperties(JsonObjectContract contract)
            {
                IList<JsonProperty> filtered = new List<JsonProperty>();
    
                foreach (JsonProperty p in base.CreateProperties(contract))
                    if(criteria.Columns.Valid.Contains(p.PropertyName)) 
                        filtered.Add(p);
                
                return filtered;
            }
    
        
