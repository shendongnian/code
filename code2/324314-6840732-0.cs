            string strRegex = @"^\d[1-9]$";
            Regex myRegex = new Regex(strRegex);
            string strTargetString = @"03"; // put here value from text box
            if (myRegex.IsMatch(strTargetString))
            {
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }
  
