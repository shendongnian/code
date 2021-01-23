    public class Cusotmer
    {
        private long? _id;
        private string _name;
        //other attributes...
        public static Customer Create(string name)
        {
            Customer customer = new Customer();
        }
        public void Validate()
        {
            if(_name == null)
                throw new ValidationException("Name has not been set.");
        }
    }
