                string password = "XXXXX";
                System.Security.SecureString securePwd = new System.Security.SecureString();
                foreach (char c in password)
                {
                    // Append the character to the password.
                    securePwd.AppendChar(c);
                }
                Process.Start("notepad", "username", securePwd, "domain");
