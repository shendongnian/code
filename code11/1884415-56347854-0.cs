       public async Task<IActionResult> OnPostAsync()
       {
            if (!ModelState.IsValid)
            {
                return Page();
            }
    
    
            _context.Users.Add(User);
            _context.UserRoles.Add(new UserRole { User = User, Role = _context.Roles.FirstOrDefault(r => r.Nome == "User")});
            
            await _context.SaveChangesAsync();
    
            _toastNotification.AddSuccessToastMessage("Utilizador Adicionado com sucesso");
    
            return RedirectToPage("./Index");
        }
