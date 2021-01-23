    public class Mask
    {
        public Mask(string originalString)
        {
            OriginalString = originalString;
            CharCategories = originalString.Select(Char.GetUnicodeCategory).ToList();
        }
        public string OriginalString { get; private set; }
        public IEnumerable<UnicodeCategory> CharCategories { get; private set; }
        public bool HasSameCharCategories(Mask other)
        {
            //null checks
            return CharCategories.SequenceEqual(other.CharCategories);
        }
    }
