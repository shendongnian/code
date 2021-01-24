    public class Person
    {
        [OptionalRequired(new string[] { nameof(MobileNumber), nameof(LandLineNumber), nameof(FaxNumber) }, MinimumAmmount = 2)]
        public string MobileNumber { get; set; }
        public string LandLineNumber { get; set; }
        public string FaxNumber { get; set; }
    }
