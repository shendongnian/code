        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement userElement = (from HtmlElement element in webBrowser1.Document.GetElementsByTagName("input") select element)
                .Where(x=>x.Id == "email").FirstOrDefault();
            if (userElement != null)
            {
                userElement.SetAttribute("value", textBox1.Text);
            }
            HtmlElement passwordElement = (from HtmlElement element in webBrowser1.Document.GetElementsByTagName("input") select element)
                .Where(x => x.Id == "pass").FirstOrDefault();
            if (passwordElement != null)
            {
                passwordElement.SetAttribute("value", textBox2.Text);
            }
        }
