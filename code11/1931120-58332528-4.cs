    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
        // Check if 'user' is an 'ExtendedUser', and if it is, use the extended properties
        var extUser = user as ExtendedUser;
        if (extUser != null)
        {
            // Do something with extUser here
        }
        // Carry on with typical 'User' activities
    }
