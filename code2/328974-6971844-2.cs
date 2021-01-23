    public static class HtmlHelper
    {
      public static string TableRow(params string[] tdList)
      {
        return string.Format("<tr>{0}</tr>", string.Format("<td>{0}</td>", string.Join("</td><td>", tdList)));
      }
    }
----------
    <table>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="CustomersSource">
            <ItemTemplate><%# HtmlHelper.TableRow(
                            Eval("CustomerID").ToString(), 
                            Eval("CompanyName").ToString()) %></ItemTemplate>
        </asp:Repeater>
    </table>
