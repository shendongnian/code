            try
            {
                using (var context = new PrincipalContext(ContextType.Machine))
                {
                    var user = UserPrincipal.FindByIdentity(context, userName);
                    if (null == user)
                    {
                        //not local user, password required
                        passwordRequired = true;
                    }
                    else
                    {
                        user.ChangePassword("", "");
                    }
                }
            }
            catch (PasswordException)
            {
                //local user password required
                passwordRequired = true;
            }
            catch (PrincipalOperationException)
            {
                //for Microsoft account, password required
                passwordRequired = true;
            }
