    enum ClauseType
    {
        And, Or
    }
    
    enum ComparisonType
    {
        Equal, NotEqual, GreaterThan, LessThan
    }
    
    interface IClause
    {
                
    }
    
    class CombinedClause : IClause
    {
        public ClauseType ClauseType { get; set; }
        public IEnumerable<IClause> SubClauses { get; set; }
    }
    
    class SingleClause : IClause
    {
        ComparisonType ComparisonType { get; set; }
        public string LeftSide { get; set; }
        public string RightSide { get; set; }
    }
    
    class Property
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    
    class Query
    {
        public IEnumerable<string> Columns { get; set; }
        public IEnumerable<string> Tables { get; set; }
        public IClause WhereClause { get; set; }
        public IEnumerable<Property> Properties { get; set; }
    }
