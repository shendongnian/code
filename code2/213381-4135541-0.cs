    public string CapitalizeFirstLetterAfterSpace(string input)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder(input);
        bool capitalizeNextLetter = true;
        for(int pos = 0; pos < sb.Length; pos++)
        {
            if(capitalizeNextLetter)
            {
                sb[pos]=System.Char.ToUpper(sb[pos]);
                capitalizeNextLetter = false;
            }
            else
            {
                sb[pos]=System.Char.ToLower(sb[pos]);
            }
    
            if(sb[pos]=' ')
            {
                capitalizeNextLetter=true;
            }
        }
    }
