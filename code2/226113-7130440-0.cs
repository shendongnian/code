            // Find text like ctr+F (NOT IN SOURCE BUT IN "WHAT YOU SEE"
            if (ie.Text.Contains("SOME TEXT TO FIND").Equals(true))
            {
                //Do stuff you would like when found here
                MessageBox.Show("Text Found! ");
            }
            else
            { 
                // cant find
            }
            //OR
    
            // Find text in SOURCE
            if (ie.Html.Contains("SOME TEXT TO FIND").Equals(true))
            {
                //Do stuff you would like when found here
                MessageBox.Show("Text Found! ");
            }
            else
            { 
                // cant find
            }
  
