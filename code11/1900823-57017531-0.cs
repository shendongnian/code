    modelBuilder.Entity<CaseType>().HasData(
    	new CaseType
    	{
    		CaseTypeId = 1, // <--
    		Name = "Case Type 1",
    	}
    );
    modelBuilder.Entity<Case>().HasData(
    	new Case
    	{
    		CaseId = 1,
    		CaseTypeId = 1, // <--
    		Name = "Case 1",
    		Description = "Case 1 Description",
    	},
    	new Case
    	{
    		CaseId = 2,
    		CaseTypeId = 1, // <--
    		Name = "Case 2",
    		Description = "Case 2 Description",
    	}
    );
