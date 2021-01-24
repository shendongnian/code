    private void TextBox_TextChanged(object sender, EventArgs e)
    {
    	if (FirstName.Text == null || LastName.Text == null || Email.Text == null || Password.Text == null || Password2.Text == null || Password.Text != Password2.Text || LastName.Text == "Last Name" && FirstName.Text == "First Name" && Email.Text == "Email")
                {
                    RegisterDone.Text = " You missed something";
                    RegisterDone.Normalcolor = Color.FromArgb(64, 64, 64);
                    RegisterDone.OnHovercolor = Color.FromArgb(64, 64, 64);
                    RegisterDone.Activecolor = Color.FromArgb(64, 64, 64);
                    RegisterDone.Textcolor = Color.FromArgb(197, 161, 89);
                    RegisterDone.OnHoverTextColor = Color.FromArgb(197, 161, 89);
                    RegisterDone.Cursor = Cursors.No;
                    RegisterDone.Iconimage = Image.FromFile(@"C:\Users\gamin\Desktop\Icons\Forbidden.png");
                }
    	if (FirstName.Text != null && LastName.Text != null && Email.Text != null && Password.Text == Password2.Text && LastName.Text != "Last Name" && FirstName.Text != "First Name" && Email.Text != "Email")
                {
                    RegisterDone.Text = "    Register right now";
                    RegisterDone.Normalcolor = Color.FromArgb(4, 41, 50);
                    RegisterDone.OnHovercolor = Color.FromArgb(4, 41, 50);
                    RegisterDone.Activecolor = Color.FromArgb(4, 41, 50);
                    RegisterDone.Textcolor = Color.FromArgb(197, 161, 89);
                    RegisterDone.OnHoverTextColor = Color.FromArgb(197, 161, 89);
                    RegisterDone.Cursor = Cursors.Hand;
                    RegisterDone.Iconimage = Image.FromFile(@"C:\Users\gamin\Desktop\Icons\Valid.png");
                }
    }
