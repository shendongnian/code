            private static string ReturnThePartOfAStringAfterTheFirstWordAndWhiteSpace(string str)
            {
                if(str.Contains(" "))
                {
                      int indexOfFirstWhiteSpace = str.IndexOf(" ");
                      string remainingStringAfterTheFirstWhiteSpace = str.Substring(indexOfFirstWhiteSpace + 1);
                      return remainingStringAfterTheFirstWhiteSpace;
                }
                else 
                      return str;
            }
