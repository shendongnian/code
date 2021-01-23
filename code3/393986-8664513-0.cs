    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" 
    AlternatingRowStyle-BackColor="#006699"  
        AlternatingRowStyle-ForeColor="#FFFFFF" onrowupdating="GridView1_RowUpdating">
    <Columns >
    <asp:BoundField HeaderText="Name" DataField="uname" />
    <asp:BoundField HeaderText="Pass" DataField="upass"/>
    <asp:TemplateField>
    <HeaderTemplate>Active</HeaderTemplate>
    <ItemTemplate >
    <asp:TextBox ID="TextArea1" runat="server" TextMode="multiline" Text='<%#Eval("active")%>'></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:ButtonField CommandName="comment" Text="comment" />
    </Columns>
    </asp:GridView>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "comment")
      {
        string uname = "";
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[index];
        TextBox txtbox1_val = (TextBox)row.FindControl("TextArea1");
        uname = Server.HtmlDecode(row.Cells[1].Text.ToString());
        //write code here
      }
    }
