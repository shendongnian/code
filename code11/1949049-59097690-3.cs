        public static IQueryable<T> FilerByProperties(string properiesFilter, IQueryable<T> query)
        {
            if (properiesFilter == null) properiesFilter = "";
            string[] properties = properiesFilter.Split(";");
            var filters = new List<DynamicFilter>();
            for (int i = 0; i < properties.Length; i++)
            {
                if (!properiesFilter.IsNullOrEmpty())
                {
                    int pocisionProp = properties[i].ToString().IndexOf('=');
                    string prop = properties[i].Substring(0, pocisionProp);
                    object value = properties[i].Substring(pocisionProp + 1);
                    if (typeof(T).GetProperty(prop) != null)
                    {
                        var badWayBuySomeWay = 0;
                        if(Int32.TryParse(value.ToString(), out badWayBuySomeWay))
                        {
                            value = badWayBuySomeWay;
                        }
                        var filter = new DynamicFilter { PropertyName = prop, Value = value };
                        filters.Add(filter);
                    }
                }
            }
            if (filters.Count > 0)
            {
                var deleg = ExpressionBuilder.GetExpression<T>(filters).Compile();
                return query.Where(deleg).AsQueryable();
            }
            return query;
        }
