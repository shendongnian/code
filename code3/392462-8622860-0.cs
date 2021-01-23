    string p1, p2, p3, p4;
            if (TextBox1.Text.Length > 5)
            {
                p1 = "pass";
                Label1.Text = "";
            }
            else
            {
                Label1.Text = "Textbox1 value should be minimum 5 characters.";
                p1 = "fail";
            }
            if (TextBox2.Text.Length > 5)
            {
                p2 = "pass";
                Label2.Text = "";
            }
            else
            {
                Label2.Text = "Textbox2 value should be minimum 5 characters.";
                p2 = "fail";
            }
            if (TextBox3.Text.Length > 5)
            {
                p3 = "pass";
                Label3.Text = "";
            }
            else
            {
                Label3.Text = "Textbox3 value should be minimum 5 characters.";
                p3 = "fail";
            }
            if (TextBox4.Text.Length > 5)
            {
                p4 = "pass";
                Label4.Text = "";
            }
            else
            {
                Label4.Text = "Textbox4 value should be minimum 5 characters.";
                p4 = "fail";
            }
            if (p1 == "pass" && p2 == "pass" && p3 == "pass" && p4 == "pass")
            {
                Status.Text = "All pass";
            }
