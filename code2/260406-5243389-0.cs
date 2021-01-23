    public MyPMan objProductManager = new MyPMan();
    public List<Product> ProductList 
    {
        get
        {
            if(Session["MyApp-ProductList"] == null)
                Session["MyApp-ProductList"] = objProductManager.GetProducts();
            return (List<Product>)Session["MyApp-ProductList"];
        }
    }
    private void FillProducts()
    {
        //List<Product> productList = objProductManager.GetProducts();
        if (this.ProductList.Count > 0)
        {
            drpProducts.DataSource = this.ProductList;
            drpProducts.DataTextField = "ProductName";
            drpProducts.DataValueField = "ProductId";
            drpProducts.DataBind();
        }
    }
