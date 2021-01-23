    bool IsDigitsOnly(string str)
        {
            if (str.Length > 0)//if contains characters
            {
                foreach (char c in str)//assign character to c
                {
                    if (c < '0' || c > '9')//check if its outside digit range
                        return false;
                }
            }else//empty string
            {
                return false;//empty string 
            }
            return true;//only digits
        }
