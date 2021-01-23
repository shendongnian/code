            public Company Employer
                {
                    get
                    {
                        return IsEmployed ? _employer : Employer.Empty; 
    // Employer.Empty is static property which return an instance of EmptyEmployer just like string.Empty.
                    
        
        }
