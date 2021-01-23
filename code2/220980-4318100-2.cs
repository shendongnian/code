    public class Regex{
        private static IEnumerable<char> DefaultAllCharacters(){ return Enumerable.Range.. }
   
        private IEnumerable<char> allCharacters;
        public IEnumerable<char> AllCharacters{
            get { return allCharacters ?? (allCharacters = DefaultAllCharacters()); }
            set { allCharacters = value; }
        }
    }
