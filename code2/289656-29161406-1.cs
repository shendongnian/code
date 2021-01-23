            InputBoxValidation validation = delegate(string val)
            {
                if (val == "")
                    return "Value cannot be empty.";
                if (!(new Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch(val))
                    return "Email address is not valid.";
                return "";
            };
            string value = "";
            if (InputBox.Show("Enter your email address", "Email address:", ref value, validation) == DialogResult.OK)
            {
               
                if (value == "thazime7@gmail.com")
                {
                    dataGridView1.Visible = true;
                    button_delete.Visible = true;
                    button1.Visible = true;
                    button_show.Visible = true;
                    label6.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    textBox_uemail.Visible = true;
                    textBox_uname.Visible = true;
                    textBox_upassword.Visible = true;
                    textBox_delete.Visible = true;
                    button_deleteTable.Visible = true;
                    button_updatep.Visible = true;
                    textBox_updateall.Visible = true;
                }
                MessageBox.Show(value);
            }
            else
            {
                MessageBox.Show("You are not authenticated");
            }
        }
