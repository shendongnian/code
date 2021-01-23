    protected override void OnPreInit(EventArgs e)
    {
    
        Label lbl = new Label();
        lbl.ID = "mylbl";
        lbl.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        form1.Controls.Add(lbl);
        for (int i = 0; i < 3; i++)
        {
            TextBox txt = new TextBox();
            txt.ID = "txt" + i;
            form1.Controls.Add(txt);
        }
    
    }
 
    protected void Button1_Click(object sender, EventArgs e)
        {
            Label lbl = form1.FindControl("mylbl") as Label;
            lbl.Text = "";
            for (int i = 0; i < 3; i++)
            {
                TextBox txt = form1.FindControl("txt" + i) as TextBox;
    
    
                lbl.Text += txt.Text;
            }
        }
