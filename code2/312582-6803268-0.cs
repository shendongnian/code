    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
           <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  OnItemDataBound="itemDataBound">
            <ItemTemplate>       
              <mycontrol:user ID="user1" runat="server" OnCausePostBack="user1_CausePostBack"  /> <br />
        </ItemTemplate>
        </asp:Repeater>
    </ContentTemplate>
    </asp:UpdatePanel>
 
    protected void itemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ModalPopup_WebUserControl mw=(ModalPopup_WebUserControl)e.Item.FindControl("user1");
        AsyncPostBackTrigger at = new AsyncPostBackTrigger();
        at.ControlID = mw.ID;
        at.EventName = "CausePostBack";
        UpdatePanel2.Triggers.Add(at);
    }
    protected void user1_CausePostBack(object sender, EventArgs e)
    {
       // do something
    }
