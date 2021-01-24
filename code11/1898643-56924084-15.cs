    public class CoutryCode
    {
        public CoutryCode() : this(null) { }
        public CoutryCode(string countryPlusCode) {
            if (!string.IsNullOrEmpty(countryPlusCode)) {
                this.CountryName = countryPlusCode.Substring(0, countryPlusCode.IndexOf("+") - 1);
                this.CountryCode = countryPlusCode.Substring(countryPlusCode.LastIndexOf("+"));
            }
        }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryAndCode => this.ToString();
        public override string ToString() => 
            this.CountryName + (char)32 + this.CountryCode;
    }
