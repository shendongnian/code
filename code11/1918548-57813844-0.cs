    class DictionaryUtils {
        
        private readonly Dictionary<int, float> BaseDct;
        public DictionaryUtils(Dictionary<int, float> dct) {
            BaseDct = dct;
        }
        public float GetMaxValue(int start, int end) {
            float[] valuesOnRange = GetSpecificRange(start, end);
            return valuesOnRange.Max();
        }
        public float GetMinValue(int start, int end) {
            float[] valuesOnRange = GetSpecificRange(start, end);
            return valuesOnRange.Min();
        }
        //return values from specific range
        private float[] GetSpecificRange(int start, int end) {
            if (start > BaseDct.Count - 1 || end > BaseDct.Count - 1) {
                throw new IndexOutOfRangeException();
            }
            Dictionary<int, float> res = new Dictionary<int, float>();
            for (int i = start; i < end; i++) {
                res.Add(BaseDct.ElementAt(i).Key,BaseDct.ElementAt(i).Value);
            }
            return res.Values.ToArray();
        }
    }
