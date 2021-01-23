    <asp:Repeater ID="RptId" runat="server" OnItemDataBound="OnItemDataBound">
      <ItemTemplate>
        <asp:Panel runat="server" ID="PnlCtrlItem">
          <%#Eval("Content") %>
        </asp:Panel>
      </ItemTemplate>
    </asp:Repeater>
    protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemIndex == 0)
          ((Panel) e.Item.FindControl("PnlCtrlItem")).CssClass = "first";
        //or the following to have your control indexed
        ((Panel) e.Item.FindControl("PnlCtrlItem")).CssClass = string.Format("item-{0}",e.Item.ItemIndex);
    }
