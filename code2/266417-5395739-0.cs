     private void SetNumber(string n)
        {
            int temp;
            bool success = Int32.TryParse(n, out temp);
            // If conversion successful
            if (success)
            {
                // If user input is negative
                if (temp < 0)
                    number = Math.Abs(temp); // Assign absolute version of user input
                else // Assign user input
                    number = temp;
            }
            else
            {
                number = 0;
            }
        }
   
