    Public Boolean Condition
    {
       get { ... }
    }
    <asp:Menu ID="..." runat="server">
      <Items>
        <asp:MenuItem Text="..." Value="..." Visible="<%# this.Condition %>" />
        
        .....
      </Items>
    </asp:Menu>
