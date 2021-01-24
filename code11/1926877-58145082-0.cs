    private bool FilterUserTableByEmail(string email)
    {
        FilterUserTableByWebElement(_regRep.FilterByNameEmail(), email);
        try
        {
            //_regRep.emailIDInTable(email);
            if (!_regRep.noDataFoundText.Displayed)
            {
                Console.WriteLine("Email for " + email + " was found in the table.");
            }
            else
            {
                Console.WriteLine("Email for " + email + " was NOT found in the table..." + ex.Message);
                return false;
            }
            return true;
            }
            catch (NoSuchElementException ex)
            {
                // the search result did not come back in the table - return false
                Console.WriteLine("Email for " + email + " was NOT found in the table..." + ex.Message);
                return false;
            }
    }
