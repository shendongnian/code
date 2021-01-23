    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("MessageID") %>'  runat="server"  CommandName="Select" >'<%# Eval("MessageTitle") %>'</asp:LinkButton>
     protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string recordID = e.CommandArgument;
        Server.Transfer("~/Moderator/ObserveMessage.aspx?MessageID=" + recordID);
    }
