    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private readonly SnakeCaseNamingStrategy _newtonsoftSnakeCaseNamingStrategy
            = new SnakeCaseNamingStrategy();
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();
        public override string ConvertName(string name)
        { 
            /* Conversion to snake case goes here.  */
            return _newtonsoftSnakeCaseNamingStrategy.GetPropertyName(name, false);
        }
    }
