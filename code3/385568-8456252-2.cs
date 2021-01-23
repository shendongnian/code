    public class TestClass
    {
        public AddressType? Type {get;set;}
        public int TypeId
        {
            get
            {
                return Type.HasValue ? Type.Value.Id : 0;
            }
        }
    }
