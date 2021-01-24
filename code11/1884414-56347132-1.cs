    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _userManager.CreateUserAsync(User);
        await _userManager.AddToRoleAsync(User, "foo"); // where "foo" is the name of your role
        _toastNotification.AddSuccessToastMessage("Utilizador Adicionado com sucesso");
        return RedirectToPage("./Index");
    }
