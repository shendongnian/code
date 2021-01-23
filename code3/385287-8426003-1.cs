    private void button1_Click(object sender, EventArgs e)
    {
        string email = "Your email";
        string password = "your password";
    
        // create a new browser
        WebBrowser w = new WebBrowser();
        w.Dock = DockStyle.Fill;
        this.Controls.Add(w); // you may add the controll to your windows forms if  you want to see what is going on
        // latter you may not chose to add the browser or you can even set it to invisible... 
    
    
        // navigate to facebook
        w.Navigate(@"http://www.facebook.com/");
    
        // wait a little
        for (int i = 0; i < 100; i++)
        {
            System.Threading.Thread.Sleep(10);
            System.Windows.Forms.Application.DoEvents();
        }
    
        
        HtmlElement temp=null;
    
        // while we find an element by id named email
        while (temp == null)
        {
            temp = w.Document.GetElementById("email");
            System.Threading.Thread.Sleep(10);
            System.Windows.Forms.Application.DoEvents();
        }
    
        // once we find it place the value
        temp.SetAttribute("value", email);
    
        
        temp = null;
        // wiat till element with id pass exists
        while (temp == null)
        {
            temp = w.Document.GetElementById("pass");
            System.Threading.Thread.Sleep(10);
            System.Windows.Forms.Application.DoEvents();
        }
        // once it exist set it value equal to passowrd
        temp.SetAttribute("value", password);
    
        // if you already found the last fields the button should also be there...
    
        var inputs = w.Document.GetElementsByTagName("input");
    
        int counter = 0;
        bool enableClick = false;
        
        // iterate through all the inputs in the document
        foreach (HtmlElement btn in inputs)
        {
            
            try
            {
                var att = btn.GetAttribute("tabindex");
                var name = btn.GetAttribute("id");
    
                if (enableClick)// button to submit always has a differnt id. it should be after password textbox
                {
                    btn.InvokeMember("click");
                    counter++;
                }
                
                if (name.ToUpper().Contains("PASS") || att=="4") 
                {
                    enableClick = true;  // button should be next to the password input                    
                }
    
                // try a max of 5 times
                if (counter > 5)
                    break;
            }
            catch
            {
    
            }
        }
    }
