    public class WorldCountry
    {
        public WorldCountry()
        {
            Name = null;
            Alpha2Code = null;
            Alpha3Code = null;
            NumericCode = null;
            Enabled = false;
        }
        public WorldCountry(string name, string alpha2Code, string alpha3Code, string numericCode, bool enabled)
        {
            Name = name;
            Alpha2Code = alpha2Code;
            Alpha3Code = alpha3Code;
            NumericCode = numericCode;
            Enabled = enabled;
        }
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public bool Enabled { get; set; }
        public override string ToString()
        {
            //Returns "USA - United States"
            return string.Format("{0} - {1}", Alpha3Code, Name);
        }
    }
    public class CountryArray
    {
        public List<WorldCountry> countries;
        public CountryArray()
        {
            countries = new List<WorldCountry>(50);
            countries.Add(new WorldCountry("Afghanistan", "AF", "AFG", "004", false));
            countries.Add(new WorldCountry("Aland Islands", "AX", "ALA", "248", false));
            countries.Add(new WorldCountry("Albania", "AL", "ALB", "008", false));
            countries.Add(new WorldCountry("Algeria", "DZ", "DZA", "012", false));
            countries.Add(new WorldCountry("American Samoa", "AS", "ASM", "016", false));
            countries.Add(new WorldCountry("Andorra", "AD", "AND", "020", false));
            countries.Add(new WorldCountry("Angola", "AO", "AGO", "024", false));
            countries.Add(new WorldCountry("Anguilla", "AI", "AIA", "660", false));
            countries.Add(new WorldCountry("Antarctica", "AQ", "ATA", "010", false));
            countries.Add(new WorldCountry("Antigua and Barbuda", "AG", "ATG", "028", false));
            countries.Add(new WorldCountry("Argentina", "AR", "ARG", "032", false));
            countries.Add(new WorldCountry("Armenia", "AM", "ARM", "051", false));
            countries.Add(new WorldCountry("Aruba", "AW", "ABW", "533", false));
            countries.Add(new WorldCountry("Australia", "AU", "AUS", "036", false));
            countries.Add(new WorldCountry("Austria", "AT", "AUT", "040", false));
            countries.Add(new WorldCountry("Azerbaijan", "AZ", "AZE", "031", false));
            countries.Add(new WorldCountry("Bahamas", "BS", "BHS", "044", false));
            countries.Add(new WorldCountry("Bahrain", "BH", "BHR", "048", false));
            countries.Add(new WorldCountry("Bangladesh", "BD", "BGD", "050", false));
            countries.Add(new WorldCountry("Barbados", "BB", "BRB", "052", false));
            countries.Add(new WorldCountry("Belarus", "BY", "BLR", "112", false));
            countries.Add(new WorldCountry("Belgium", "BE", "BEL", "056", false));
            countries.Add(new WorldCountry("Belize", "BZ", "BLZ", "084", false));
            countries.Add(new WorldCountry("Benin", "BJ", "BEN", "204", false));
            countries.Add(new WorldCountry("Bermuda", "BM", "BMU", "060", false));
            countries.Add(new WorldCountry("Bhutan", "BT", "BTN", "064", false));
            countries.Add(new WorldCountry("Bolivia, Plurinational State of", "BO", "BOL", "068", false));
            countries.Add(new WorldCountry("Bonaire, Sint Eustatius and Saba", "BQ", "BES", "535", false));
            countries.Add(new WorldCountry("Bosnia and Herzegovina", "BA", "BIH", "070", false));
            countries.Add(new WorldCountry("Botswana", "BW", "BWA", "072", false));
            countries.Add(new WorldCountry("Bouvet Island", "BV", "BVT", "074", false));
            countries.Add(new WorldCountry("Brazil", "BR", "BRA", "076", false));
            countries.Add(new WorldCountry("British Indian Ocean Territory", "IO", "IOT", "086", false));
            countries.Add(new WorldCountry("Brunei Darussalam", "BN", "BRN", "096", false));
            countries.Add(new WorldCountry("Bulgaria", "BG", "BGR", "100", false));
            countries.Add(new WorldCountry("Burkina Faso", "BF", "BFA", "854", false));
            countries.Add(new WorldCountry("Burundi", "BI", "BDI", "108", false));
            countries.Add(new WorldCountry("Cambodia", "KH", "KHM", "116", false));
            countries.Add(new WorldCountry("Cameroon", "CM", "CMR", "120", false));
            countries.Add(new WorldCountry("Canada", "CA", "CAN", "124", true));
            countries.Add(new WorldCountry("Cape Verde", "CV", "CPV", "132", false));
            countries.Add(new WorldCountry("Cayman Islands", "KY", "CYM", "136", false));
            countries.Add(new WorldCountry("Central African Republic", "CF", "CAF", "140", false));
            countries.Add(new WorldCountry("Chad", "TD", "TCD", "148", false));
            countries.Add(new WorldCountry("Chile", "CL", "CHL", "152", false));
            countries.Add(new WorldCountry("China", "CN", "CHN", "156", false));
            countries.Add(new WorldCountry("Christmas Island", "CX", "CXR", "162", false));
            countries.Add(new WorldCountry("Cocos (Keeling) Islands", "CC", "CCK", "166", false));
            countries.Add(new WorldCountry("Colombia", "CO", "COL", "170", false));
            countries.Add(new WorldCountry("Comoros", "KM", "COM", "174", false));
            countries.Add(new WorldCountry("Congo", "CG", "COG", "178", false));
            countries.Add(new WorldCountry("Congo, the Democratic Republic of the", "CD", "COD", "180", false));
            countries.Add(new WorldCountry("Cook Islands", "CK", "COK", "184", false));
            countries.Add(new WorldCountry("Costa Rica", "CR", "CRI", "188", false));
            countries.Add(new WorldCountry("Cote d'Ivoire", "CI", "CIV", "384", false));
            countries.Add(new WorldCountry("Croatia", "HR", "HRV", "191", false));
            countries.Add(new WorldCountry("Cuba", "CU", "CUB", "192", false));
            countries.Add(new WorldCountry("Curacao", "CW", "CUW", "531", false));
            countries.Add(new WorldCountry("Cyprus", "CY", "CYP", "196", false));
            countries.Add(new WorldCountry("Czech Republic", "CZ", "CZE", "203", false));
            countries.Add(new WorldCountry("Denmark", "DK", "DNK", "208", false));
            countries.Add(new WorldCountry("Djibouti", "DJ", "DJI", "262", false));
            countries.Add(new WorldCountry("Dominica", "DM", "DMA", "212", false));
            countries.Add(new WorldCountry("Dominican Republic", "DO", "DOM", "214", false));
            countries.Add(new WorldCountry("Ecuador", "EC", "ECU", "218", false));
            countries.Add(new WorldCountry("Egypt", "EG", "EGY", "818", false));
            countries.Add(new WorldCountry("El Salvador", "SV", "SLV", "222", false));
            countries.Add(new WorldCountry("Equatorial Guinea", "GQ", "GNQ", "226", false));
            countries.Add(new WorldCountry("Eritrea", "ER", "ERI", "232", false));
            countries.Add(new WorldCountry("Estonia", "EE", "EST", "233", false));
            countries.Add(new WorldCountry("Ethiopia", "ET", "ETH", "231", false));
            countries.Add(new WorldCountry("Falkland Islands (Malvinas)", "FK", "FLK", "238", false));
            countries.Add(new WorldCountry("Faroe Islands", "FO", "FRO", "234", false));
            countries.Add(new WorldCountry("Fiji", "FJ", "FJI", "242", false));
            countries.Add(new WorldCountry("Finland", "FI", "FIN", "246", false));
            countries.Add(new WorldCountry("France", "FR", "FRA", "250", false));
            countries.Add(new WorldCountry("French Guiana", "GF", "GUF", "254", false));
            countries.Add(new WorldCountry("French Polynesia", "PF", "PYF", "258", false));
            countries.Add(new WorldCountry("French Southern Territories", "TF", "ATF", "260", false));
            countries.Add(new WorldCountry("Gabon", "GA", "GAB", "266", false));
            countries.Add(new WorldCountry("Gambia", "GM", "GMB", "270", false));
            countries.Add(new WorldCountry("Georgia", "GE", "GEO", "268", false));
            countries.Add(new WorldCountry("Germany", "DE", "DEU", "276", false));
            countries.Add(new WorldCountry("Ghana", "GH", "GHA", "288", false));
            countries.Add(new WorldCountry("Gibraltar", "GI", "GIB", "292", false));
            countries.Add(new WorldCountry("Greece", "GR", "GRC", "300", false));
            countries.Add(new WorldCountry("Greenland", "GL", "GRL", "304", false));
            countries.Add(new WorldCountry("Grenada", "GD", "GRD", "308", false));
            countries.Add(new WorldCountry("Guadeloupe", "GP", "GLP", "312", false));
            countries.Add(new WorldCountry("Guam", "GU", "GUM", "316", false));
            countries.Add(new WorldCountry("Guatemala", "GT", "GTM", "320", false));
            countries.Add(new WorldCountry("Guernsey", "GG", "GGY", "831", false));
            countries.Add(new WorldCountry("Guinea", "GN", "GIN", "324", false));
            countries.Add(new WorldCountry("Guinea-Bissau", "GW", "GNB", "624", false));
            countries.Add(new WorldCountry("Guyana", "GY", "GUY", "328", false));
            countries.Add(new WorldCountry("Haiti", "HT", "HTI", "332", false));
            countries.Add(new WorldCountry("Heard Island and McDonald Islands", "HM", "HMD", "334", false));
            countries.Add(new WorldCountry("Holy See (Vatican City State)", "VA", "VAT", "336", false));
            countries.Add(new WorldCountry("Honduras", "HN", "HND", "340", false));
            countries.Add(new WorldCountry("Hong Kong", "HK", "HKG", "344", false));
            countries.Add(new WorldCountry("Hungary", "HU", "HUN", "348", false));
            countries.Add(new WorldCountry("Iceland", "IS", "ISL", "352", false));
            countries.Add(new WorldCountry("India", "IN", "IND", "356", false));
            countries.Add(new WorldCountry("Indonesia", "ID", "IDN", "360", false));
            countries.Add(new WorldCountry("Iran, Islamic Republic of", "IR", "IRN", "364", false));
            countries.Add(new WorldCountry("Iraq", "IQ", "IRQ", "368", false));
            countries.Add(new WorldCountry("Ireland", "IE", "IRL", "372", false));
            countries.Add(new WorldCountry("Isle of Man", "IM", "IMN", "833", false));
            countries.Add(new WorldCountry("Israel", "IL", "ISR", "376", false));
            countries.Add(new WorldCountry("Italy", "IT", "ITA", "380", false));
            countries.Add(new WorldCountry("Jamaica", "JM", "JAM", "388", false));
            countries.Add(new WorldCountry("Japan", "JP", "JPN", "392", false));
            countries.Add(new WorldCountry("Jersey", "JE", "JEY", "832", false));
            countries.Add(new WorldCountry("Jordan", "JO", "JOR", "400", false));
            countries.Add(new WorldCountry("Kazakhstan", "KZ", "KAZ", "398", false));
            countries.Add(new WorldCountry("Kenya", "KE", "KEN", "404", false));
            countries.Add(new WorldCountry("Kiribati", "KI", "KIR", "296", false));
            countries.Add(new WorldCountry("Korea, Democratic People's Republic of", "KP", "PRK", "408", false));
            countries.Add(new WorldCountry("Korea, Republic of", "KR", "KOR", "410", false));
            countries.Add(new WorldCountry("Kuwait", "KW", "KWT", "414", false));
            countries.Add(new WorldCountry("Kyrgyzstan", "KG", "KGZ", "417", false));
            countries.Add(new WorldCountry("Lao People's Democratic Republic", "LA", "LAO", "418", false));
            countries.Add(new WorldCountry("Latvia", "LV", "LVA", "428", false));
            countries.Add(new WorldCountry("Lebanon", "LB", "LBN", "422", false));
            countries.Add(new WorldCountry("Lesotho", "LS", "LSO", "426", false));
            countries.Add(new WorldCountry("Liberia", "LR", "LBR", "430", false));
            countries.Add(new WorldCountry("Libya", "LY", "LBY", "434", false));
            countries.Add(new WorldCountry("Liechtenstein", "LI", "LIE", "438", false));
            countries.Add(new WorldCountry("Lithuania", "LT", "LTU", "440", false));
            countries.Add(new WorldCountry("Luxembourg", "LU", "LUX", "442", false));
            countries.Add(new WorldCountry("Macao", "MO", "MAC", "446", false));
            countries.Add(new WorldCountry("Macedonia, the former Yugoslav Republic of", "MK", "MKD", "807", false));
            countries.Add(new WorldCountry("Madagascar", "MG", "MDG", "450", false));
            countries.Add(new WorldCountry("Malawi", "MW", "MWI", "454", false));
            countries.Add(new WorldCountry("Malaysia", "MY", "MYS", "458", false));
            countries.Add(new WorldCountry("Maldives", "MV", "MDV", "462", false));
            countries.Add(new WorldCountry("Mali", "ML", "MLI", "466", false));
            countries.Add(new WorldCountry("Malta", "MT", "MLT", "470", false));
            countries.Add(new WorldCountry("Marshall Islands", "MH", "MHL", "584", false));
            countries.Add(new WorldCountry("Martinique", "MQ", "MTQ", "474", false));
            countries.Add(new WorldCountry("Mauritania", "MR", "MRT", "478", false));
            countries.Add(new WorldCountry("Mauritius", "MU", "MUS", "480", false));
            countries.Add(new WorldCountry("Mayotte", "YT", "MYT", "175", false));
            countries.Add(new WorldCountry("Mexico", "MX", "MEX", "484", false));
            countries.Add(new WorldCountry("Micronesia, Federated States of", "FM", "FSM", "583", false));
            countries.Add(new WorldCountry("Moldova, Republic of", "MD", "MDA", "498", false));
            countries.Add(new WorldCountry("Monaco", "MC", "MCO", "492", false));
            countries.Add(new WorldCountry("Mongolia", "MN", "MNG", "496", false));
            countries.Add(new WorldCountry("Montenegro", "ME", "MNE", "499", false));
            countries.Add(new WorldCountry("Montserrat", "MS", "MSR", "500", false));
            countries.Add(new WorldCountry("Morocco", "MA", "MAR", "504", false));
            countries.Add(new WorldCountry("Mozambique", "MZ", "MOZ", "508", false));
            countries.Add(new WorldCountry("Myanmar", "MM", "MMR", "104", false));
            countries.Add(new WorldCountry("Namibia", "NA", "NAM", "516", false));
            countries.Add(new WorldCountry("Nauru", "NR", "NRU", "520", false));
            countries.Add(new WorldCountry("Nepal", "NP", "NPL", "524", false));
            countries.Add(new WorldCountry("Netherlands", "NL", "NLD", "528", false));
            countries.Add(new WorldCountry("New Caledonia", "NC", "NCL", "540", false));
            countries.Add(new WorldCountry("New Zealand", "NZ", "NZL", "554", false));
            countries.Add(new WorldCountry("Nicaragua", "NI", "NIC", "558", false));
            countries.Add(new WorldCountry("Niger", "NE", "NER", "562", false));
            countries.Add(new WorldCountry("Nigeria", "NG", "NGA", "566", false));
            countries.Add(new WorldCountry("Niue", "NU", "NIU", "570", false));
            countries.Add(new WorldCountry("Norfolk Island", "NF", "NFK", "574", false));
            countries.Add(new WorldCountry("Northern Mariana Islands", "MP", "MNP", "580", false));
            countries.Add(new WorldCountry("Norway", "NO", "NOR", "578", false));
            countries.Add(new WorldCountry("Oman", "OM", "OMN", "512", false));
            countries.Add(new WorldCountry("Pakistan", "PK", "PAK", "586", false));
            countries.Add(new WorldCountry("Palau", "PW", "PLW", "585", false));
            countries.Add(new WorldCountry("Palestine, State of", "PS", "PSE", "275", false));
            countries.Add(new WorldCountry("Panama", "PA", "PAN", "591", false));
            countries.Add(new WorldCountry("Papua New Guinea", "PG", "PNG", "598", false));
            countries.Add(new WorldCountry("Paraguay", "PY", "PRY", "600", false));
            countries.Add(new WorldCountry("Peru", "PE", "PER", "604", false));
            countries.Add(new WorldCountry("Philippines", "PH", "PHL", "608", false));
            countries.Add(new WorldCountry("Pitcairn", "PN", "PCN", "612", false));
            countries.Add(new WorldCountry("Poland", "PL", "POL", "616", false));
            countries.Add(new WorldCountry("Portugal", "PT", "PRT", "620", false));
            countries.Add(new WorldCountry("Puerto Rico", "PR", "PRI", "630", false));
            countries.Add(new WorldCountry("Qatar", "QA", "QAT", "634", false));
            countries.Add(new WorldCountry("Reunion", "RE", "REU", "638", false));
            countries.Add(new WorldCountry("Romania", "RO", "ROU", "642", false));
            countries.Add(new WorldCountry("Russian Federation", "RU", "RUS", "643", false));
            countries.Add(new WorldCountry("Rwanda", "RW", "RWA", "646", false));
            countries.Add(new WorldCountry("Saint BarthÃ©lemy", "BL", "BLM", "652", false));
            countries.Add(new WorldCountry("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", "654", false));
            countries.Add(new WorldCountry("Saint Kitts and Nevis", "KN", "KNA", "659", false));
            countries.Add(new WorldCountry("Saint Lucia", "LC", "LCA", "662", false));
            countries.Add(new WorldCountry("Saint Martin (French part)", "MF", "MAF", "663", false));
            countries.Add(new WorldCountry("Saint Pierre and Miquelon", "PM", "SPM", "666", false));
            countries.Add(new WorldCountry("Saint Vincent and the Grenadines", "VC", "VCT", "670", false));
            countries.Add(new WorldCountry("Samoa", "WS", "WSM", "882", false));
            countries.Add(new WorldCountry("San Marino", "SM", "SMR", "674", false));
            countries.Add(new WorldCountry("Sao Tome and Principe", "ST", "STP", "678", false));
            countries.Add(new WorldCountry("Saudi Arabia", "SA", "SAU", "682", false));
            countries.Add(new WorldCountry("Senegal", "SN", "SEN", "686", false));
            countries.Add(new WorldCountry("Serbia", "RS", "SRB", "688", false));
            countries.Add(new WorldCountry("Seychelles", "SC", "SYC", "690", false));
            countries.Add(new WorldCountry("Sierra Leone", "SL", "SLE", "694", false));
            countries.Add(new WorldCountry("Singapore", "SG", "SGP", "702", false));
            countries.Add(new WorldCountry("Sint Maarten (Dutch part)", "SX", "SXM", "534", false));
            countries.Add(new WorldCountry("Slovakia", "SK", "SVK", "703", false));
            countries.Add(new WorldCountry("Slovenia", "SI", "SVN", "705", false));
            countries.Add(new WorldCountry("Solomon Islands", "SB", "SLB", "090", false));
            countries.Add(new WorldCountry("Somalia", "SO", "SOM", "706", false));
            countries.Add(new WorldCountry("South Africa", "ZA", "ZAF", "710", false));
            countries.Add(new WorldCountry("South Georgia and the South Sandwich Islands", "GS", "SGS", "239", false));
            countries.Add(new WorldCountry("South Sudan", "SS", "SSD", "728", false));
            countries.Add(new WorldCountry("Spain", "ES", "ESP", "724", false));
            countries.Add(new WorldCountry("Sri Lanka", "LK", "LKA", "144", false));
            countries.Add(new WorldCountry("Sudan", "SD", "SDN", "729", false));
            countries.Add(new WorldCountry("Suriname", "SR", "SUR", "740", false));
            countries.Add(new WorldCountry("Svalbard and Jan Mayen", "SJ", "SJM", "744", false));
            countries.Add(new WorldCountry("Swaziland", "SZ", "SWZ", "748", false));
            countries.Add(new WorldCountry("Sweden", "SE", "SWE", "752", false));
            countries.Add(new WorldCountry("Switzerland", "CH", "CHE", "756", false));
            countries.Add(new WorldCountry("Syrian Arab Republic", "SY", "SYR", "760", false));
            countries.Add(new WorldCountry("Taiwan, Province of China", "TW", "TWN", "158", false));
            countries.Add(new WorldCountry("Tajikistan", "TJ", "TJK", "762", false));
            countries.Add(new WorldCountry("Tanzania, United Republic of", "TZ", "TZA", "834", false));
            countries.Add(new WorldCountry("Thailand", "TH", "THA", "764", false));
            countries.Add(new WorldCountry("Timor-Leste", "TL", "TLS", "626", false));
            countries.Add(new WorldCountry("Togo", "TG", "TGO", "768", false));
            countries.Add(new WorldCountry("Tokelau", "TK", "TKL", "772", false));
            countries.Add(new WorldCountry("Tonga", "TO", "TON", "776", false));
            countries.Add(new WorldCountry("Trinidad and Tobago", "TT", "TTO", "780", false));
            countries.Add(new WorldCountry("Tunisia", "TN", "TUN", "788", false));
            countries.Add(new WorldCountry("Turkey", "TR", "TUR", "792", false));
            countries.Add(new WorldCountry("Turkmenistan", "TM", "TKM", "795", false));
            countries.Add(new WorldCountry("Turks and Caicos Islands", "TC", "TCA", "796", false));
            countries.Add(new WorldCountry("Tuvalu", "TV", "TUV", "798", false));
            countries.Add(new WorldCountry("Uganda", "UG", "UGA", "800", false));
            countries.Add(new WorldCountry("Ukraine", "UA", "UKR", "804", false));
            countries.Add(new WorldCountry("United Arab Emirates", "AE", "ARE", "784", false));
            countries.Add(new WorldCountry("United Kingdom", "GB", "GBR", "826", false));
            countries.Add(new WorldCountry("United States", "US", "USA", "840", true));
            countries.Add(new WorldCountry("United States Minor Outlying Islands", "UM", "UMI", "581", false));
            countries.Add(new WorldCountry("Uruguay", "UY", "URY", "858", false));
            countries.Add(new WorldCountry("Uzbekistan", "UZ", "UZB", "860", false));
            countries.Add(new WorldCountry("Vanuatu", "VU", "VUT", "548", false));
            countries.Add(new WorldCountry("Venezuela, Bolivarian Republic of", "VE", "VEN", "862", false));
            countries.Add(new WorldCountry("Viet Nam", "VN", "VNM", "704", false));
            countries.Add(new WorldCountry("Virgin Islands, British", "VG", "VGB", "092", false));
            countries.Add(new WorldCountry("Virgin Islands, U.S.", "VI", "VIR", "850", false));
            countries.Add(new WorldCountry("Wallis and Futuna", "WF", "WLF", "876", false));
            countries.Add(new WorldCountry("Western Sahara", "EH", "ESH", "732", false));
            countries.Add(new WorldCountry("Yemen", "YE", "YEM", "887", false));
            countries.Add(new WorldCountry("Zambia", "ZM", "ZMB", "894", false));
            countries.Add(new WorldCountry("Zimbabwe", "ZW", "ZWE", "716", false));
        }
        /// <summary>
        /// List of 3 digit abbreviated country codes
        /// </summary>
        /// <returns></returns>
        public string[] Alpha3Codes()
        {
            List<string> abbrevList = new List<string>(countries.Count);
            foreach (var country in countries)
            {
                if (country.Enabled)
                    abbrevList.Add(country.Alpha3Code);
            }
            return abbrevList.ToArray();
        }
        /// <summary>
        /// List of 2 digit abbreviated country codes
        /// </summary>
        /// <returns></returns>
        public string[] Alpha2Codes()
        {
            List<string> abbrevList = new List<string>(countries.Count);
            foreach (var country in countries)
            {
                if (country.Enabled)
                    abbrevList.Add(country.Alpha2Code);
            }
            return abbrevList.ToArray();
        }
        /// <summary>
        /// List of Country names
        /// </summary>
        /// <returns></returns>
        public string[] Names()
        {
            List<string> nameList = new List<string>(countries.Count);
            foreach (var country in countries)
            {
                if (country.Enabled)
                    nameList.Add(country.Name);
            }
            return nameList.ToArray();
        }
        /// <summary>
        /// List of Countries
        /// </summary>
        /// <returns></returns>
        public WorldCountry[] Countries()
        {
            return countries.Where(c => c.Enabled == true).ToArray();
        }
    }
