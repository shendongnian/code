                try // you need to use try catch when you only have local user
                {
                    valid = checkpass.ValidateCredentials(user, password);
                }
                catch (Exception ex) { valid = true; }
                if (valid)
                  {
                 // returns ok   
                   }
                else
                    {
                    // returns false
                    }
