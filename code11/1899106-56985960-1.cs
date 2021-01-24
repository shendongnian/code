    private void button1_Click(object sender, EventArgs e)
    {
        // User name
        HtmlElement userElement = (from HtmlElement element in webBrowser1.Document.GetElementsByTagName("input") select element)
            .Where(x=>x.Id == "email").FirstOrDefault();
    
        if (userElement != null)
        {
            userElement.SetAttribute("value", textBox1.Text);
        }
    
        // Password
        HtmlElement passwordElement = (from HtmlElement element in webBrowser1.Document.GetElementsByTagName("input") select element)
            .Where(x => x.Id == "pass").FirstOrDefault();
    
        if (passwordElement != null)
        {
            passwordElement.SetAttribute("value", textBox2.Text);
        }
    
        // Submit
        HtmlElement submitElement = (from HtmlElement element in webBrowser1.Document.GetElementsByTagName("input") select element)
            .Where(x => x.Id == "u_0_a").FirstOrDefault();
        if (submitElement != null)
        {
            submitElement.InvokeMember("click");
        }    
    }
