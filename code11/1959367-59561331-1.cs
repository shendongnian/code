    public IActionResult OnPostSave()
    {
        var fb = Request.Form;
    
        var selected_items = string.Join(",", fb.Keys.ToList().Take(fb.Keys.Count - 1));
    
        //code logic to save selected items
    
        Console.WriteLine("Save button clicked!!");
        
    
        return RedirectToPage();
    }
