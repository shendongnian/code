    public class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
        public override void ToString()
        {
            // return whatever makes sense here...
            return string.Format("[Person: FirstName={0}, LastName={1}, Age={2}]", FirstName, LastName, Age);
        }
    }
