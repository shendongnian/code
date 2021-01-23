    browser.Document.MouseDown += new HtmlEventHandler(Browser_MouseDown);
    void Browser_MouseDown(object sender, HtmlElementEventArgs e)
    { 
         if (e.MouseButtonsPressed == System.Windows.Forms.MouseButtons.Middle)
         {
             e.ReturnValue = false;
             
             // Your custom code
         }
    }
