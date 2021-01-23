     public static object GetSalesDataBySaleOrderID(SaleOrder sale)
     {
         List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
         for (int i = 0; i < sale.saleOrderItem.Count(); i++)
         {
             Dictionary<string, object> result = new Dictionary<string, object>()
             {
                {"SaleId", sale.Id},
                {"UserName", sale.User.GetSingleUserById(sale.saleOrderItem[i].UserId).Name},
                {"Amount", sale.saleOrderItem[i].Amount},
             };
             list.Add(result);
         }
         return list.Select (d => new { Id=(int)d["SaleId"], Username  = d["UserName"], Amount = (Decimal) d["Amount"]});
     } 
