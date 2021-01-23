    public class ModelStateError {
        public string Property { get; set; }
        public string Error { get; set; }
    
        public ModelStateError(string key, string value) {
            this.Property = key;
            this.Error = value;
        }
    }
