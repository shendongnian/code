    string input = "red HOUSE";
    System.Text.StringBuilder sb = new System.Text.StringBuilder(input);
    
    for (int j = 0; j < sb.Length; j++)
    {
        if ( j == 0 ) //catches just the first letter
            sb[j] = System.Char.ToUpper(sb[j]);
        else  //everything else is lower case
            sb[j] = System.Char.ToLower(sb[j]);
    }
    // Store the new string.
    string corrected = sb.ToString();
    System.Console.WriteLine(corrected);
