    public bool ValidateSIN()
    {
        string sin = txtSIN.Text;
        
        if ((int)Char.GetNumericValue(sin[0]) == 0)
        {
            return false;
        }
        else
        {
            string evenString = "";
            int totalOfEvens = 0;
            int totalOfOdds = 0;
            int total, nextMultipleOfTen, remainder;
            int checkDigit = (int)Char.GetNumericValue(sin[8]);
    
            // multiply each even number of the input string by 2
            // get the resulting numbers into a string so the chars 
            // can be manipulated as individual digits
            for (int i = 1; i <= 7; i += 2)
            {
                evenString += (Char.GetNumericValue(sin[i]) * 2);
            }
    
            // add the individual digits of the products from the above loop
            foreach (char c in evenString)
            {
                totalOfEvens += (int)Char.GetNumericValue(c);
            }
    
            // get the odd numbers of the input string, minus the last number,
            // and add them together
            for (int i = 0; i <= 6; i += 2)
            {
                totalOfOdds += (int)Char.GetNumericValue(sin[i]);
            }
      
            total = totalOfEvens + totalOfOdds;
        
            // take the quotient of total divided by 10 and add 1 to get the next multiple of ten
            nextMultipleOfTen = (Math.DivRem(total, 10, out remainder) + 1) * 10;
        
            if ((total % 10 == 0 && checkDigit == 0) || (checkDigit == nextMultipleOfTen - total))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }      
