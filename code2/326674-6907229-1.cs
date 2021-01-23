    public class SaleItem
    {    
        public string saleTitle {get;set;}   
    }
    List<SaleItem> resultsList = new List<SaleItem>();
    SqlDataReader reader = doMainQuery.ExecuteReader();
    var resultsList = reader.AsQueryable().Cast<SaleItem>().Select(x => x.saleTitle).Distinct().ToList();
                      
    showResults.DataSource = resultsList;
    showResults.DataBind();
    <asp:repeater id="showResults" Runat="server"   >
        <ItemTemplate>
          <%# Eval("saleTitle")%>
        </ItemTemplate>
    </asp:repeater>
