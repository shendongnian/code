    public interface IPerson<T>
    {
        List<T> Get();
    }
    
    class aPerson : IPerson<Person>
    {
        public List<Person> Get() 
        {
            var aLst = new List<Person>()
            {
                new Person { id = "1001", name = "John" },
                new Person { id = "1002", name = "Jack" }
            };
            return aLst;
        }
    }
