    public List<object> lstStock = new List<object>();
     public void PopulateStockList()
        {
            XmlRpcClient stock = new XmlRpcClient();
            stock.Url = LocalApplication.Url;
            stock.Path = "common";
            //LOGIN BG
            XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
            requestLogin.AddParams(LocalApplication.Db, LocalApplication.User, 
    LocalApplication.Pass,
                XmlRpcParameter.EmptyStruct());
            XmlRpcResponse responseLogin = stock.Execute(requestLogin);
            //READ
            stock.Path = "object";
            XmlRpcRequest requestSearch = new XmlRpcRequest("execute_kw");
            requestSearch.AddParams(LocalApplication.Db, responseLogin.GetInt(),
                LocalApplication.Pass, "stock.quant", "search_read",
                XmlRpcParameter.AsArray(
                    XmlRpcParameter.AsArray(
                        XmlRpcParameter.AsArray("id", ">", 0)
                    )
                ),
                XmlRpcParameter.AsStruct(
                    XmlRpcParameter.AsMember("fields",
                        XmlRpcParameter.AsArray("product_id", "quantity", "in_date", 
    "owner_id"))
                )
            );
            XmlRpcResponse responseSearch = stock.Execute(requestSearch);
            lstStock = (responseSearch.GetObject() as List<object>);
        }
