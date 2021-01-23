                var impessonate = new Impersonate(".", "User", "Psw");
                if (impessonate.ImpersonateValidUser())
                {
                    // do stuff
                    impessonate.UndoImpersonation();
                }
