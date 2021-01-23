    public class SaleItem
    {    
        public string saleTitle {get;set;}   
    }
    public static class Extension
    {
        public static IEnumerable<T> Select<T>(this SqlDataReader reader, Func<SqlDataReader, T> projection)
        {
            while (reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
    List<SaleItem> resultsList = new List<SaleItem>();
    SqlDataReader reader = doMainQuery.ExecuteReader();
    var resultsList = reader.Select(x => new SaleItem { saleTitle = x["saleTitle"].ToString() }).Distinct().ToList();
                      
    showResults.DataSource = resultsList;
    showResults.DataBind();
    <asp:repeater id="showResults" Runat="server"   >
        <ItemTemplate>
          <%# Eval("saleTitle")%>
        </ItemTemplate>
    </asp:repeater>
