    public bool AccountExists(string name)
            {
                bool SidExists = false;
                try
                {
                    NTAccount Acct = new NTAccount(name);
                    SecurityIdentifier id = (SecurityIdentifier)Acct.Translate(typeof(SecurityIdentifier));
                    SidExists = id.IsAccountSid();
                }
                catch (IdentityNotMappedException)
                {
                    //Oh snap.
                }
                return SidExists;
            }
