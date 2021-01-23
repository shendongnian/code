    public class MissingPropertyChain : DynamicObject
    {
        private string property;
     
        public MissingPropertyChain(string property)
        {
            this.property = property;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) 
        {
            if(binder.Name == "ToString")
                result = "Missing property: " + property;
            else
                result = new MissingPropertyChain( property + "." + binder.Name;
            return true;
        }
    }
