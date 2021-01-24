    interface PersonFilter{
        bool Pass(Person p);
    }
    
    class ChildFilter : PersonFilter
    {
        public bool Pass(Person p)
        {
            return person.Age <= 10;
        }
    }
    
    class PuberFilter : PersonFilter
    {
        public bool Pass(Person p)
        {
            return person.Age > 10 && person.Age < 18;
        }
    }
    
    class AdultFilter : PersonFilter
    {
        public bool Pass(Person p)
        {
            return person.Age > 18;
        }
    }
