    <asp:LinkButton ID="lnkdelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID")%>'>Delete</asp:LinkButton>
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "Delete")
        {
          int ID = Convert.ToInt32(e.CommandArgument);
          //now perform the delete operation using ID value
        }
    }
    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)    
    {
    //Leave it blank
    }
