     private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            
           
           if (toggleSwitch1.IsOn==true)
            {
                string a= textBox2.Text;
                textBox2.PasswordChar = '\0';
            }
            if (toggleSwitch1.IsOn==false)
            {
                textBox2.PasswordChar = '*';
            }
        }
