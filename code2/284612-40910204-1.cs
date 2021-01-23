                var input = password;
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new Exception("Password should not be empty");
                }
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{8,15}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
                if (!hasLowerChar.IsMatch(input))
                {
                    throw new Exception("Password should contain At least one lower case letter");
                }
                else if (!hasUpperChar.IsMatch(input))
                {
                    throw new Exception("Password should contain At least one upper case letter");
                }
                else if (!hasMiniMaxChars.IsMatch(input))
                {
                    throw new Exception("Password should not be less than or greater than 12 characters");
                }
                else if (!hasNumber.IsMatch(input))
                {
                    throw new Exception("Password should contain At least one numeric value");
                }
                else if (!hasSymbols.IsMatch(input))
                {
                    throw new Exception("Password should contain At least one special case characters");
                }
                else
                {
                    return true;
                }
           
        }
