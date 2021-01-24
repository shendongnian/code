    internal class MongoDBFieldAttribute : Attribute
    {
        public string Field{ get; private set; }
        public MongoDBFieldAttribute(string field)
        {
            this.Field= field;
        }
    }
