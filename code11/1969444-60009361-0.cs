    // typical delimiter characters
    char[] delimiterChars = { ' ' };
    // verify the name exists
    if (!String.IsNullOrEmpty(name))
    {
        // Get the list of strings
        string[] strings = name.Split(delimiterChars);
  
        if (strings != null)
        {
            if (strings.Length == 1)
            {
               firstName = strings[0];
            }
            else if (strings.Length == 2)
            {
               firstName = strings[0];
               lastName = strings[1];
            }
            else if (strings.Length == 3)
            {
               firstName = strings[0];
               middleName = strings[1];
               lastName = strings[2];
            }
        }
    }
    
