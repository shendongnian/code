    public Country GetCountryByTaxID(int taxID)
            {
                if (taxID == 3 || taxID == 4)
                {
                    return Country.USA;
                }
                else 
                {
                    return Country.Canada;
                }
            }  
