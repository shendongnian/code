    [ViewContext]
    public ViewContext ViewContext { get; set; }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // ...
    
        var claimsPrincipal = ViewContext.HttpContext.User;
        var identityUser = await _um.GetUserAsync(claimsPrincipal);
        if (identityUser == null)
        {
            // Either no user is signed in or there's no match for the user in Identity.
            // ...
        }
    
        bool isInRole = _um.IsInRoleAsync(identityUser, this.Roles);
        // ...
    }
