        protected void Button1_Click(object sender, EventArgs e)
        {
            //wait five seconds to demonstrate the idea
            System.Threading.Thread.Sleep(5000);
            //update page content
            Label1.Text = "Stuff in the background has finished executing and the page has been loaded with the new content.";
        }
