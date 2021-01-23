      public bool IsBase64(string base64String)
        {
            try
            {
                if (!base64String.Length < 1)
                {
                    if (!base64String.Equals(Convert.ToBase64String(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(Convert.FromBase64String(base64String)))), StringComparison.InvariantCultureIgnoreCase) & !System.Text.RegularExpressions.Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,2}$"))
                    {
                        return false;
    					return;
                    }
                    if ((base64String.Length % 4) != 0 || string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0 || base64String.Contains(" ") || base64String.Contains(Constants.vbTab) || base64String.Contains(Constants.vbCr) || base64String.Contains(Constants.vbLf))
                    {
                        return false;
    					return;
                    }
                }
                else
    			{
    				return false;
    				return;
    			}
                    
                return true;
    			return;
            }
            catch (FormatException ex)
            {
                return false;
    			return;
            }
        }
