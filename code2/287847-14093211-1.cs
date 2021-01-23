    string[] arg = new string[10];
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        for (int i = 0; i < 10; i++)
        {
            LinkButton bb = new LinkButton();
            arg[i]= bb.ID = "bb" + i.ToString();
            bb.Text = "like"+"<br/>";
            Panel1.Controls.Add(bb);
            bb.Click += new EventHandler(bb_Click);
        }
    }
    void bb_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        for (int j = 0; j < 10; j++)
        {
            if (btn.ID == arg[j])
            {
                btn.Text = "";
                btn.Text = "unlike";
                Response.Write(arg[j]);
            }
        }
    }
