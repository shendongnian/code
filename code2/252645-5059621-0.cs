    1: <asp:ListView ID="ListView1" runat="server" onitemcommand="ListView1_ItemCommand">
        
    2:  <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Save">Save</asp:LinkButton> 
    
    3:   
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
            {
                if (e.CommandName == "Save")
                {
                    TextBox tb = (TextBox)e.Item.FindControl("TextBox1");
                    string x = tb.Text;
                }
            }
