    static class DctExt {
        public static void GetKeysByValueInRange(this Dictionary<int,float> baseDct, int start, int end, out List<int> byMinValue, out List<int> byMaxValue) {
            byMinValue = new List<int>();
            byMaxValue = new List<int>();
            float max = GetMaxValue(baseDct, start, end);
            float min = GetMinValue(baseDct, start, end);
            foreach (KeyValuePair<int, float> kvp in baseDct) {
                if(kvp.Value == min) {
                    byMinValue.Add(kvp.Key);
                }
                else if(kvp.Value == max) {
                    byMaxValue.Add(kvp.Key);
                }
            }
        }
        private static float GetMaxValue(Dictionary<int,float> baseDct, int start, int end) {
            List<float> valuesOnRange = GetSpecificRange(baseDct, start, end);
            return valuesOnRange.Max();
        }
        private static float GetMinValue(Dictionary<int,float> baseDct, int start, int end) {
            List<float> valuesOnRange = GetSpecificRange(baseDct, start, end);
            return valuesOnRange.Min();
        }
        private static List<float> GetSpecificRange(Dictionary<int,float> dct, int start, int end) {
            List<float> res = new List<float>();
            for (int i = start; i < end; i++) {
                res.Add(dct.ElementAt(i).Value);
            }
            return res;
        }
    }
