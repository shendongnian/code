    public void ClearText(List<Control> items)
            {
                foreach (Control control in items)
                {
                    if (control is TextBox)
                        ((TextBox)control).Text = string.Empty;
                    else if (control is DigitBox)
                        ((DigitBox)control).Text = string.Empty;
                    else
                    { // Handle anything else.}
                }
            }
     
