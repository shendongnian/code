    public enum OrangeAssociations
    {
        [AssociationQueryString("Orange Families")]
        OrangeFamilies
    }
    public class AssociationQueryStringAttribute : System.Attribute
    {
        private readonly string value;
        public string Value { get { return this.value; } }
        public AssociationQueryStringAttribute(string value)
        {
            this.value = value;
        }
    }
