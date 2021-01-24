    public class ResultItem {
        public ResultItem(string fieldName, string targetValue, string sourceValue) {
            this.fieldName = fieldName;
            this.targetValue = targetValue;
            this.sourceValue = sourceValue;
        }
        public string fieldName { get; set; }
        public string targetValue { get; set; }
        public string sourceValue { get; set; }
    }
