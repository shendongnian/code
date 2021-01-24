        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(@"D:\DemoFolder\demo.html");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Get a link
            HtmlElement  link = (from HtmlElement element in webBrowser1.Document.GetElementsByTagName("link") select element)
                .Where(x => x.GetAttribute("rel") != null && x.GetAttribute("rel") == "stylesheet" && x.GetAttribute("href") != null).FirstOrDefault();
            if (link != null)
            {
                // Get CSS path
                string path = link.GetAttribute("href");
                string text = File.ReadAllText(path);
                textBox1.Text = text;
            }
        }
