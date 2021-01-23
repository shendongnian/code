    class MongoQueryAll
        {
            public string Name { get; set; }
            public List<MongoQueryElement> QueryElements { get; set; }
            public MongoQueryAll(string name)
           {
               Name = name;
               QueryElements = new List<MongoQueryElement>();
           }
           public override string ToString()
           {
               string qelems = "";
               foreach (var qe in QueryElements)
                  qelems = qelems + qe + ",";
               string query = String.Format(@"{{ ""{0}"" : {{ $all : [ {1} ] }} }}", this.Name, qelems); 
 
               return query;
           }
      }
    class MongoQueryElement
    {
        public List<MongoQueryPredicate> QueryPredicates { get; set; }
        public MongoQueryElement()
        {
            QueryPredicates = new List<MongoQueryPredicate>();
        }
        public override string ToString()
        {
            string predicates = "";
            foreach (var qp in QueryPredicates)
            {
                predicates = predicates + qp.ToString() + ",";
            }
          
            return String.Format(@"{{ ""$elemMatch"" : {{ {0} }} }}", predicates);
        }
    }
    class MongoQueryPredicate
    {        
        public string Name { get; set; }
        public object Value { get; set; }
        public MongoQueryPredicate(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            if (this.Value is int)
                return String.Format(@" ""{0}"" : {1} ", this.Name, this.Value);
            
            return String.Format(@" ""{0}"" : ""{1}"" ", this.Name, this.Value);
        }
    }
