    public class LocalizedRequiredAttribute : RequiredAttribute {
        public LocalizedRequiredAttribute() { /* TypeDef = typeof(Resources);*/ }
    }
    public class MyModel {
        [LocalizedRequired]
        public string RequiredStringWithDesc { get; set; }
    }
