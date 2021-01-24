    public static class StandardCodes
    {
        public static Colors Colors = new Colors();
        public static class Person
        {
            public static HairColors HairColors = new HairColors();
        }
    }
    public class Colors
    {
        public readonly string Black = "BLK - Black";
        public readonly string Gray  = "GRY - Gray";
        public readonly string White = "WHI - White";
    }
    public class HairColors : Colors
    {
        public readonly string Blonde = "BLN - Blond or Strawberry";
        public readonly string Sandy  = "SDY - Sandy";
    }
    
