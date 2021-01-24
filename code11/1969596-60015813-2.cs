    public class TypeReflector
    {
        public Person Reflect<T>(Case<T> person) where T:Person
        {
            return person.PersonType;
        }
    }
