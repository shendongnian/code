            string hashedPassword = Security.CreateHash("password");
            if (Security.VerifyPassword(hashedPassword, "password"))
            {
                Response.Write("Valid");
            }
            else
            {
                Response.Write("Not Valid");
            }
