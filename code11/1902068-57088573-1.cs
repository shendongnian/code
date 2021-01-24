    public async Task<IActionResult> OnPostSaveChangesAsync(List<TestRowFatContent> testRowFatContents, List<TestRowSaltExtract> testRowSaltExtracts, List<TestRowWaterAbsorption> testRowWaterAbsorptions, List<TestRowTensileStrength> testRowTensileStrength)
    {
    	//Check if your list objects are filled with the user input, the name attribute of the input fields need to match the variable names above
    	
    	//tell the context what you want to update 
    	_context.UpdateRange(testRowFatContents);
    	_context.UpdateRange(testRowSaltExtracts);
    	_context.UpdateRange(testRowWaterAbsorptions);
    	_context.UpdateRange(testRowTensileStrength);
    	_context.SaveChanges(); 
    	
    	return Page();
    }
