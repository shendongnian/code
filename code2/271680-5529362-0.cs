    System.Security.Principal.IPrincipal _user = System.Threading.Thread.CurrentPrincipal;
                if (_user.IsInRole("admin"))
                {
                    //Set link to admin link
                }
                else
                {
                    //Set to other link
                }
