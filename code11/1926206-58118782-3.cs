        public static bool CheckPropertyCompare(CustomerModel customer, Exclude item)
        {
            var dicRelation = getRelationPropertyAttribute(typeof(CustomerModel));
            var propertyName = dicRelation[item.SourceCol];
            var propertyValue = GetPropValue(customer, propertyName);
            return item.Values.Value.ToList().Contains(propertyValue);
        }
