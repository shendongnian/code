    public class Person<T> where T : Address, new()
    {
        public T address;
    
        public Person()
        {
            this.address.Country = new Country();
        }
    }
