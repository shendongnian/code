    public class TypeReflector
    {
        public Person Reflect<T>(Case<T> person) where T:Person
        {
            if (person.PersonType.IsGood)
                return person.PersonType;
            return person.PersonType;
        }
    }
