    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
    	var itemToDelete = await _mapRepo.GetByIdAsync(id);
    	if (itemToDelete == null)
    	{
    		//...
    	}
    
    	await _mapRepo.Delete(itemToDelete);
    	return RedirectToPage("Maps");
    }
