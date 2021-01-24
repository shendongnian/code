       int results = 0;
            foreach(RadioButton rb in groupBox1.Controls)
            {
                if (rb.Checked)
                {
                    results = int.Parse(rb.Text.Substring(0,1)); //You can change it if result >= 10
                    break;
                }
            }
    
