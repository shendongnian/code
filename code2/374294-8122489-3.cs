    <asp:TemplateField HeaderText="Status" SortExpression="MessageStatus">
        <ItemTemplate>
           <asp:Image ID="Status" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    public YourObject
    {
       public string MessageStatus {get; set;}
       ..........
    }
