    public class GetAllCriteria
    {
        public Dictionary<Expression<Func<CustomType, object>>, bool> ToBeOrderedBy 
        { 
            get; private set;
        }
        
        public GetAllCriteria OrderBy(
            Expression<Func<CustomType, object>> expression)
        {
            return OrderBy(expression, true);
        }
        
        public GetAllCriteria OrderByDescending(
            Expression<Func<CustomType, object>> expression)
        {
            return OrderBy(expression, false);
        }
        
        private GetAllCriteria OrderBy(
            Expression<Func<CustomType, object>> expression, bool isAscending)
        {
            if (expression != null)
            {
                if (ToBeOrderedBy == null)
                    ToBeOrderedBy = new Dictionary<Expression<Func<CustomType, object>>, bool>();
                ToBeOrderedBy.Add(expression, isAscending);
            }
            return this;
        }   
    }
