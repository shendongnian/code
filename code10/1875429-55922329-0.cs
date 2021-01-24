    public async Task<IActionResult> OnPostAsync(CreateEditProduct model, IFormFile imageFile, string existingImage)
    {
    
        if (!ModelState.IsValid) return Page();
    
        if (imageFile != null)
        {
            var fileName = imageFile.FileName;
            [...]
            model.Product.Image = fileName;
        }
    
        if (await TryUpdateModelAsync(
            model.Product,
            "Product",
            x => x.Image,
            [...]
        )){
            _dbContext.Update(model); // or model.Product if you only need to save changes to Product
            await _dbContext.SaveChangesAsync();
        }
