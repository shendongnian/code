`
private void textBox18_Validating(object sender, CancelEventArgs e)
        {
            Regex r = new Regex(@"^[+-]?[0-9]{3}\.[0-9]{3}$");
            Match m = r.Match(((TextBox)sender).Text);
            if (!m.Success)
         
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
              
                
            }
        }
`
