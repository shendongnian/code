    List<ProductSQL> myObjectList = new List<ProductSQL>();
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        connection.Open();
        var reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                ProductSQL myObject = new ProductSQL();
                myObject.sku = reader["sku"].ToString();  
                myObject.description = reader["description"].ToString();
                myObjectList.Add(myObject);
            }
        }
        var JsonResult = JsonConvert.SerializeObject(myObjectList);
        Console.WriteLine(JsonResult);
    }
    
    
    /* Program Initialization Now need to map the products to their respective fields from the SQL Database to the API*/
    
    Console.WriteLine("Post Articles To API");
    HttpResponseMessage response2;
    foreach(ProductSQL product in myObjectList.ToList())
    {
        Product NewProduct = new Product();
        NewProduct.sku = product.sku;
        NewProduct.title = product.title;
        NewProduct.description =product.description;
    }
