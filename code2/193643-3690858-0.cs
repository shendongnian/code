    public class Country
    {
        public string Name { get; set; }
        public string Iso3166TwoLetterCode { get; set; }
        public static Country GetCountry(string userHost)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(userHost, out ipAddress))
            {
                return new Country 
                {
                    Name = ipAddress.Country(),
                    Iso3166TwoLetterCode = ipAddress.Iso3166TwoLetterCode()
                };
            }
            return null;
        }
    }
