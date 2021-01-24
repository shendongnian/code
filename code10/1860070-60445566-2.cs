    [HttpPost]
    [PreventDoublePost]
    public async Task<IActionResult> Edit(EditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            //PreventDoublePost Attribute makes ModelState invalid
        }
        throw new NotImplementedException();
    }
