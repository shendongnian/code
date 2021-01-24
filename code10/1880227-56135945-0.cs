        {
        var user=await userManager.FindByNameAsync(User.Identity.Name);
        }
        if(await signInManager.IsSignedInAsync(user)){
        //Do other stuffs with the user.
        }
