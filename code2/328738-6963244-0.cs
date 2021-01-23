    public class LicenceType
    {
        private string name;
        public LicenceType(string Name)
        {
            this.name = Name;
        }
        public override string ToString()
        {
            return name;
        }
    }
    public static class LicenceTypes
    {
        public static LicenceType DISCOUNT = new LicenceType("DISCOUNT");
        public static LicenceType DISCOUNT_EARLY_ADOPTER= new LicenceType("DISCOUNT EARLY-ADOPTER");
        public static LicenceType COMMERCIAL= new LicenceType("COMMERCIAL");
        public static LicenceType COMMERCIAL_EARLY_ADOPTER= new LicenceType("COMMERCIAL EARLY-ADOPTER");
    }
