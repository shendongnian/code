    public async Task<ActionResult> OnPostClearSearch()
    {
        Gender = "";
        ModelState.Clear();
        InitSearchList();
        return Page();
    }
