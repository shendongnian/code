            WebApplication7.linqDataContext db = new WebApplication7.linqDataContext();
            var users = from usr in db.uporabnikis
                        select usr.username,usr.password;
            bool result = false;
            
            foreach(var user in users)
            {
                if(user.username.Equals("usernametocheck") && user.password.Equals("passwordtocheck"))
                {
                    result = true;
                    break;
                }
            }
            if(result)
            {
                //code to redirect
            }
            else
            {
                //Display error
            }
        }
