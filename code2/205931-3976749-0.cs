    <script type="text/javascript">
            function ButtonClick(buttonId) {
                alert("Button " + buttonId + " clicked from javascript");
            }
        </script> 
    
        protected void Button_Click(object sender, EventArgs e)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), ((Button)sender).ID, "<script>alert('Button_Click');</script>");
                Response.Write(DateTime.Now.ToString() + ": " + ((Button)sender).ID + " was clicked");
            }
    
    
       private Button GetButton(string id, string name)
            {
                Button b = new Button();
                b.Text = name;
                b.ID = id;
                b.Click += new EventHandler(Button_Click);
                b.OnClientClick = "ButtonClick('" + b.ClientID + "')";
                return b;
            }
