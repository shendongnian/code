    public static class StandardCodes
    {
        public static Colors Colors = new Colors();
        public static class Person
        {
            public static HairColors HairColors = new HairColors();
        }
        
        public class Colors
        {
            public const string Black = "BLK - Black";
            public const string Gray  = "GRY - Gray";
            public const string White = "WHI - White";
        }
        public class HairColors : Colors
        {
            public const string Blonde = "BLN - Blond or Strawberry";
            public const string Sandy  = "SDY - Sandy";
        }
    }
