     [AllowAnonymous]
     public IActionResult AccessDenied()
     {
        return RedirectToPage("/Error");
     }
