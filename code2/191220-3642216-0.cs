    public partial class Person 
    {
        public static Person CreatePerson(string lastName, string firstName)
        {
            return CreatePerson(-1, lastName, firstName);
        }
    }
