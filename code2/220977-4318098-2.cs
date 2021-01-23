    public class Revex
    {
        public IEnumerable<char> AllCharacters
        {
            get
            {
                if (mAllCharacters == null)
                {
                    // Default initialization
                    mAllCharacters 
                        = Enumerable.Range(0, 256)
                          .Select(Convert.ToChar)
                          .Where(c => !char.IsControl(c)
                }
                return mAllCharacters;
            }
        }
        public Revex()
        {
            // Nothing
        }
        private IEnumerable<char> mAllCharacters;
    }
