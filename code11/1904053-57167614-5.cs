    public class PersonViewModel
    {
        public Person person = new Person();
        public PersonViewModel() // constructor
        {
            person.FirstName = "Iain";
        }
        public void Test() // method
        {
            person.FirstName = "Pete";
        }
    }
