    		protected void PostBack(object sender, System.EventArgs e)
    		{
    			this.TextBox2.Text += "\n\nGot an asp.net postback\n\n"
    				+ string.Format("PostBack for - {0}\n", ((System.Web.UI.Control)sender).ID);
    		}
