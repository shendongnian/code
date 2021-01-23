                string strRegex = @"^(\d{10})$";
            Regex myRegex = new Regex(strRegex);
            string strTargetString = textBox.Text;
            if(myRegex.IsMatch(strTargetString))
            {
                //all is ok
            }
            else
            {
                //incorrect input
            }
