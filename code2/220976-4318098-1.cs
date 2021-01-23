    public class Revex
    {
        public IEnumerable<char> AllCharacters;
        public Revex()
            : this( Enumerable.Range(0, 256)
                    .Select(Convert.ToChar)
                    .Where(c => !char.IsControl(c))
        {
            // Nothing
        }
        public Revex(IEnumerable<char> allCharacters)
        {
            AllCharacters = allCharacters.ToArray();
        }
    }
