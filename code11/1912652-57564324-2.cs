    public static class CardDimensionRequirementExtensions
    {
        public static void AddItem(this IDictionary<int, CardDimensionRequirementLine> dictionary, int PictureCount, int Length, int Height, int BootstrapDimension)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            dictionary.Add(PictureCount, new CardDimensionRequirementLine(PictureCount, Length, Height, BootstrapDimension));
        }
        public static int GetMaxKey(this IDictionary<int, CardDimensionRequirementLine> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            return dictionary.Keys.Max();
        }   
    }
