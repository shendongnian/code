    public class NumberSuffixProviderFactory
    {
        public INumberSuffixProvider GetProvider(Language language)
        {
            switch (name)
            {
                case Language.English: return new EnglishNumberSuffixProvider();
                case Language.German: return new GermanNumberSuffixProvider();
                // etc., etc. -- this is just for illustration
                default: throw new ArgumentException("Unknown language.");
            }
        }
    }
