    public class SandwichRepository
    {
        Sandwich _saved;
    
        public void Save(Sandwich sandwich)
        {
            _saved = sandwich;
        }
    
        public Sandwich GetSandwichByName(string validSandwichName)
        {
            if (_saved.ValidSandwichName == validSandwichName)
                return _saved;
    
            return null;
        }
    }
    
    public class Sandwich
    {
        public string ValidSandwichName
        {
            get;
            set;
        }
    
        public Sandwich(string validSandwichName)
        {
            ValidSandwichName = validSandwichName;
        }
    }
