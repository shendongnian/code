    var result = myDataContext.MyTable
        .Where(sale => /* my conditions */)
        .AsEnumerable() // use LINQ to objects at this point
        .Select(sale =>
        {
            dynamic exo = new ExpandoObject();
            exo.SaleId = sale.Id;
            exo.UserName = sale.User.GetSingleUserById(sale.saleOrderItem[i].UserId).Name;
            exo.Amount = sale.saleOrderItem[i].Amount;
            return exo as IDictionary<string, object>;
        });
    IDictionary<string, object> first = result.First();
    // access the properties as if it were a dictionary
    var saleId = (int)first["SaleId"]; // get (and cast) the SaleId property
    first["UserName"] = "Bob"; // set the UserName property
    // cast it back to dynamic to access the properties as if it were an anonymous object
    dynamic dfirst = first;
    var amount = dfirst.Amount; // get the Amount property (no cast necessary)
    dfirst.Amount = 3238132.12M // set the Amount property
