    private void toggleSwitch1_Toggled(object sender, EventArgs e)
    {
        if (toggleSwitch1.IsOn)
        {
            string a= textBox2.Text;
            textBox2.PasswordChar = '\0';
        }
        else
        {
            textBox2.PasswordChar = '*';
        }
    }
