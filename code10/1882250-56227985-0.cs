            // assumed file strings
            var usernames = "Username1\n" + 
                            "Username2\n" +
                            "username3";
            var passwords = "Password1\n" +
                            "Password2\n" +
                            "Password3";
            // Split it for each line
            var usernamesfile = usernames.Split("\n"); 
            var passwordsfile = passwords.Split("\n");
            var sb = new StringBuilder();
            for (int i = 0; i < usernamesfile.Length; i++)
            {
                sb.AppendLine($"{usernamesfile[i]}:{passwordsfile[i]}");
            }
            // Username1:Password1
            // Username2:Password2
            // username3:Password3
            var bothLines = sb.ToString();
