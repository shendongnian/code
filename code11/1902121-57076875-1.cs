    Product product = new Product
    {
                Name = "Gizmo",
                Price = 100,
                Category = "Widgets"
    };    
    var url = await CreateProductAsync(product);
    static async Task<Uri> CreateProductAsync(Product product)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/products", product);
        response.EnsureSuccessStatusCode();
    
        // return URI of the created resource.
        return response.Headers.Location;
    }
