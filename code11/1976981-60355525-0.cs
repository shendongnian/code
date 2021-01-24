var identity = new ClaimsIdentity(e.Identity);
                IUserRepository dUser = new UserRepository(new DARDbEntities());
                var userName = identity.Name.Split('\\')[1];
                User user = dUser.Get(userName);
                if(user == null)
                {
                    Response.Redirect("401.html");
                }
I was being too cute with the custom errors stuff.
