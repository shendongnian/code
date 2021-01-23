            var Rxwhitesp = new Regex(@"\s");
            string textboxstring = textbox.Text;
            string textboxfirststring = textbox.Text.First().ToString();
            if (Rxwhitesp.IsMatch(textboxfirststring) && (textboxstring.Length == 1))
            {
                // write code for true condition
            }
            else
            {
                // write code for false condition
            }
