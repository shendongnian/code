    <asp:TemplateField HeaderText="Date">
        <ItemTemplate>
          <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField HeaderText="Checkbox">
            <ItemTemplate>
               <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                        oncheckedchanged="CheckBox1_CheckedChanged" />
             </ItemTemplate>
    </asp:TemplateField>
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
       String Date = ((Label)((CheckBox)sender).Parent.FindControl("lblDate")).Text;
    }
