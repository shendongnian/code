    public static int PreviousIndex;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ddlName.AppendDataBoundItems = true;
                    ddlName.Items.Add(new ListItem("Other", "4"));
                    PreviousIndex = ddlName.SelectedIndex;
                }
    
            }
    
            protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
            {
                string GetPreviousValue = ddlName.Items[PreviousIndex].Text;
                Response.Write("This is Previously Selected Value"+ GetPreviousValue);
                //Do selected change event here.
    
                PreviousIndex = ddlName.SelectedIndex;
    
            }
