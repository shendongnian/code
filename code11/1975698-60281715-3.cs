    /// <summary>
    /// This method performs initializations for this object.
    /// </summary>
    public void Init()
    {
        // Set defaults
        this.NoAction = true;
        Action = "";
        ProfileImageUrl = NoProfileImagePath;
        ShowUploadButton = true;
        Name = "Login";
        // Create a new collection of 'IBlazorComponent' objects.
        this.Children = new List<IBlazorComponent>();
        // Erase the displayName property
        displayName = "";
        // if RememberLogin is false
        if (!RememberLogin)
        {
            // Erase all these values
            EmailAddress = "";
            Password = "";
            StoredPasswordHash = "";
        }
    }
