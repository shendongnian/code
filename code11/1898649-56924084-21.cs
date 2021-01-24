    public class CountryCode
    {
        public CountryCode() { }
        public string Country { get; set; }
        public string Code { get; set; }
        public string CountryAndCode => this.ToString();
        public override string ToString() => this.Country + (char)32 + this.Code;
    }
