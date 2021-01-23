    public class CustomerModel:Customer{}
    public class ModelFactoryImp:ModelFactory{
        public Customer CreateCustomer(int id,//...customer params){
            return new CustomerModel(...);
        }
    }
