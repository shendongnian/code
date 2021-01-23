    public class GrainType
    {
        private string _typeKeyWord;
        public GrainType(string typeKeyWord)
        {
            _typeKeyWord = typeKeyWord;
        }
        public override string ToString()
        {
            return _typeKeyWord;
        }
        public static GrainType Wheat = new GrainType("GT_WHEAT");
        public static GrainType Corn = new GrainType("GT_CORN");
        public static GrainType Rice = new GrainType("GT_RICE");
        public static GrainType Maize = new GrainType("GT_MAIZE");
    }
