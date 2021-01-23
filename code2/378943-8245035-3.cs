    void Main ()
    {
        int x = 1;
        int y = 1;
    
        var exp1 = new ConditionBuilder (() => x != 3);
        var exp2 = new ConditionBuilder (() => y != 5);
        var exp3 = exp1 & exp2;
    
        Console.WriteLine (exp3.Execute ());
    }
    
    public class ConditionBuilder
    {
        private readonly Expression<Func<bool>> _filter;
    
        public ConditionBuilder(Expression<Func<bool>> filter) {
            _filter = filter;
        }
        
        public bool Execute() {
            return _filter.Compile()();
        }
    
        public static ConditionBuilder And(ConditionBuilder left, ConditionBuilder right) {
            return new ConditionBuilder(Expression.Lambda<Func<bool>>(Expression.AndAlso(left._filter.Body, right._filter.Body)));
        }
    
        public static ConditionBuilder Or(ConditionBuilder left, ConditionBuilder right) {
            return new ConditionBuilder(Expression.Lambda<Func<bool>>(Expression.OrElse(left._filter.Body, right._filter.Body)));
        }
        
        public static ConditionBuilder operator & (ConditionBuilder left, ConditionBuilder right) {
            // Note this could confuse users for the problem discussed below.
            // Consider using Expression.And instead of AndAlso
            return ConditionBuilder.And(left, right);
        }
        
        public static ConditionBuilder operator | (ConditionBuilder left, ConditionBuilder right) {
            // Note this could confuse users for the problem discussed below.
            // Consider using Expression.Or instead of OrElse
            return ConditionBuilder.Or(left, right);
        }
    }
