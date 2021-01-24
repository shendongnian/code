        public class HybridDictionary: IDictionary {
 
        // These numbers have been carefully tested to be optimal. Please don't change them
        // without doing thorough performance testing.
        private const int CutoverPoint = 9;
        private const int InitialHashtableSize = 13;
        private const int FixedSizeCutoverPoint = 6;     
