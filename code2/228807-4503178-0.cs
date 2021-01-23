    public Country GetCountryByTaxID(int taxID)
            {
                if (taxID == 3 || taxID == 4)
                {
                    return Country.US;
                }
                else 
                {
                    return Country.Canada;
                }
            }
