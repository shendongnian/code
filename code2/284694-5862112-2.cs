    public class CustomerDAO{
        private ModelFactory _modelFactory;
        public CustomerDAO(ModelFactory modelFactory){
             _modelFactory = modelFactory;
        }
        public Customer LoadCustomer(int id)
        { 
            // Data Access Code
            return _modelFactory.CreateCustomer(id,//...cutomer params);
        }
    }
