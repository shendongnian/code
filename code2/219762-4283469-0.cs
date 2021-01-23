    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<string, string> values = new Dictionary<string, string>();
        if (this.IsPostBack)
        {
            foreach (var control in this.Controls)
            {
                 TextBox textbox = control as TextBox;
                 if (textbox != null)
                 {
                     values.Add(textbox.ID, Server.HtmlEncode(textbox.Text));
                 }
            }        
        }
    }
