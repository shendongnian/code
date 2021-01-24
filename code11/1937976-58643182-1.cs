    private void textBox5_Click(object sender, EventArgs e)
        {
            if(!textBox5.Text.Equals(String.Empty))
            {
                String p = webBrowser1.Url.AbsolutePath;
                if(!textBox6.Text.Equals(String.Empty))
                {
                    webBrowser1.Url = new Uri(p.Replace(@"/" + textBox6.Text, ""));
                }
            }
        }
