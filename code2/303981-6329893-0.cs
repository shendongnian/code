    DataTable products = ds.Tables["Product"];
    var query = products.AsEnumerable().
    Select(product => new
    {
        ProductName = product.Field<string>("Name"),
        ProductNumber = product.Field<string>("ProductNumber"),
        Price = product.Field<decimal>("ListPrice")
    });
