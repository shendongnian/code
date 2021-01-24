    interface PersonFilter{
        bool Pass(Person person);
    }
    
    class ChildFilter : PersonFilter
    {
        public bool Pass(Person person)
        {
            return person.Age <= 10;
        }
    }
    
    class PuberFilter : PersonFilter
    {
        public bool Pass(Person person)
        {
            return person.Age > 10 && person.Age < 18;
        }
    }
    
    class AdultFilter : PersonFilter
    {
        public bool Pass(Person person)
        {
            return person.Age > 18;
        }
    }
