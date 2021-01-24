cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
You then need to change from onclick to a grid command:
<asp:TemplateField>
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server"Text="Download" 
                      ControlStyle-CssClass="btn btn-success" CommandName="MyCommand" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
    </ItemTemplate>
</asp:TemplateField>
And in your code behind
protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if(e.CommandName.Equals("MyCommand"))
    {
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        string val = (string)this.grid.DataKeys[rowIndex]["id"];
        // you can run your query here
    }
}
In your case:
 protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName.Equals("MyCommand"))
    {
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        string val = (string)this.GridView1.DataKeys[rowIndex]["id"];
        string strQuery = "SELECT filename, filecontent, datestamp FROM FileTable where id=@id";
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(val);
        DataTable dt = GetData(cmd);
        if (dt != null)
        {
            download(dt);
        }
    }
}
You need to also add the `onrowcommand="ContactsGridView_RowCommand"` to your Gridview
<asp:GridView ID="GridView1" runat="server" onrowcommand="ContactsGridView_RowCommand"
