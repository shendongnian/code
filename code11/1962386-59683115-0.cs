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
    
    // ... respective classes for Puber and Adult
