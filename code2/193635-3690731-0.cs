    using System.Net;
    using WorldDomination.Net;
    
    string userHostIpAddress = "203.1.2.3";
    IPAddress ipAddress;
    if (IPAddress.TryParse(userHostIpAddress, out ipAddress))
    {
        string country = ipAddress.Country(); // return value: UNITED STATES
        string iso3166TwoLetterCode = ipAddress.Iso3166TwoLetterCode(); // return value: US
    }
