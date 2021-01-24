    public class YourOptions {
        public int Value { get; set; } => SomeDefaultValue;
    }
    
    public class YourService : IYourService {
        private readonly YourOptions options
    
        public YourService (YourOptions options) {
            this.options = options;
        }
    
        public bool GetSomething() {
            if (options.Value == 1)
                return true;
    
            return false;
        }
    }
