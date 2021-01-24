    public class CardDimensionRequirement : IDictionary<int, CardDimensionRequirementLine>
    {
        readonly Dictionary<int, CardDimensionRequirementLine> dictionary = new Dictionary<int, CardDimensionRequirementLine>();
        public void AddItem(int PictureCount, int Length, int Height, int BootstrapDimension)
        {
            Add(PictureCount, new CardDimensionRequirementLine(PictureCount, Length, Height, BootstrapDimension));
        }
        public int GetMaxKey()
        {
            return Keys.Max();
        }   
        #region IDictionary<int,CardDimensionRequirementLine> Members
        // Delegate everything to this.dictionary:
        public void Add(int key, CardDimensionRequirementLine value)
        {
            this.dictionary.Add(key, value);
        }
        // Remainder snipped
