        public IEnumerable<string> GetValues(List<PropertyInfo> objects)
        {
            var allValues = new List<string>();
            foreach (var obj in objects)
            {
                // Get the PropertyInfo for the obj 
                var properties = GetPropertiesWithTheAttributes(obj);
                var values = properties.Select(x => new
                                                        {
                                                            Value = GetValue(obj, x),
                                                            Order = GetOrder(x)
                                                        })
                    .OrderBy(x => x.Order)
                    .Select(x => x.Value.ToString())
                    .ToList();
                allValues.AddRange(values);
            }
            return allValues;
        }
