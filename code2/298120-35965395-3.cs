     Credential credentials= new Credential
                {
                    Username = "Usernmae",
                    Password = "Password",
                    Target = "Target (usualy proxy domain)",
                    Type = CredentialType.Generic,
                    PersistanceType = PersistanceType.Enterprise
                };
                credentials.Save();
