    private List<T> SortList<T>(List<T> collection, SortOrder order, string propertyName) where T : class
            {
                if (order == SortOrder.Descending)
                {
                    return collection.OrderByDescending(cc => cc.GetType().GetProperty(propertyName).GetValue(cc, null)).ToList();
                }
    
                return collection.OrderBy(cc => cc.GetType().GetProperty(propertyName).GetValue(cc, null)).ToList();
            }
