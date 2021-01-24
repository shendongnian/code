                //checks if the user is is authenticated
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    //checks if the user has a role
                    if (User.IsInRole("user"))
                    {
                    }
                }
