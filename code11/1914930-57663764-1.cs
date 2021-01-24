    public sealed class BirdType : TypeSafeEnumBase
    {
        private const int BlueBirdId = 1;
        private const int RedBirdId = 2;
        private const int GreenBirdId = 3;
        public static readonly BirdType BlueBird = 
            new BirdType(BlueBirdId, nameof(BlueBird), "Blue Bird");
        public static readonly BirdType RedBird = 
            new BirdType(RedBirdId, nameof(RedBird), "Red Bird");
        public static readonly BirdType GreenBird = 
            new BirdType(GreenBirdId, nameof(GreenBird), "Green Bird");
        
        private BirdType(int value, string name, string displayName) :
            base(value, name)
        {
            DisplayName = displayName;
        }
        public string DisplayName { get; }
        public static BirdType Parse(int value)
        {
            switch (value)
            {
                case BlueBirdId:
                    return BlueBird;
                case RedBirdId:
                    return RedBird;
                case GreenBirdId:
                    return GreenBird;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), $"Unable to parse for value, '{value}'. Not found.");
            }
        }
        public static BirdType Parse(string value)
        {
            switch (value)
            {
                case "Blue Bird":
                case nameof(BlueBird):
                    return BlueBird;
                case "Red Bird":
                case nameof(RedBird):
                    return RedBird;
                case "Green Bird":
                case nameof(GreenBird):
                    return GreenBird;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), $"Unable to parse for value, '{value}'. Not found.");
            }
        }
        public static bool TryParse(int value, out BirdType type)
        {
            try
            {
                type = Parse(value);
                return true;
            }
            catch
            {
                type = null;
                return false;
            }
        }
        public static bool TryParse(string value, out BirdType type)
        {
            try
            {
                type = Parse(value);
                return true;
            }
            catch
            {
                type = null;
                return false;
            }
        }
    }
