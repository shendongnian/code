    private void txtbox1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                if (txtbox1.Text.Equals("your origional text"))
                {
                    Name_Text.Text = "";
                }
            }
    private void txtbox1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                if (Name_Text.Text.Equals(""))
                {
                    Name_Text.Text = "your origional text";
                }
            }
