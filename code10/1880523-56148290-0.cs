        bool Verify(string input)
        {
            input = input.Replace("%", "");  // if it contains % remove it
            int value;
            if (Int32.TryParse(input, out value))   //if the input can be converted into a number
            {
                if (value > 1 && value < 100)  //and the value is in range
                {
                    return true;  //return true to confirm it
                }
            }
            return false;  //in any other case return false
        }
