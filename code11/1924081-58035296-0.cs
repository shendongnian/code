lang-csharp
public static DataTable SelectedSaleDetails(string saleId)
{
    DataTable dt = new DataTable();
    dt = DataAccess.Select(string.Format("select * from vSalesDetails where SaleID = {0}", saleId));
    
    DataTable result = new DataTable();
    result.Columns.Add("ProductName");
    result.Columns.Add("Variation");
    result.Columns.Add("UnitCost");
    result.Columns.Add("Quantity");
    result.Columns.Add("SaleCost");
    foreach (DataRow drItem in dt.Rows)
    {
       // Massage the data like you're doing...
       // And replace the assignment to values with...
       
       var row = result.NewRow();
       row["ProductName"] = productName;
       row["Variation"] = variation;
       row["UnitCost"] = unitCost.ToString();
       row["Quanity"] = quantity.ToString();
       row["SaleCost"] = saleCost.ToString();
       result.Add(row);
    }
    return result;
}
On a side note, you probably want to see about changing `DataAccess.Select` to handle parameterized queries. As it is now, you might have a [SQL Injection Vulnerability](https://en.wikipedia.org/wiki/SQL_injection).
