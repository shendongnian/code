     public string DownloadRpcStock()
        {
            try
            {
                PopulateProdTemplate();
                PopulateStockList();
                PopulateProductList();
                Stock s = new Stock(LocalApplication.ConnectionString);
                foreach (var st in lstStock)
                {
                    Dictionary<string, object> stc = st as Dictionary<string, object>;
                    var productId = stc["product_id"] as List<object>;
                    if (productId != null)
                        s.IdProduct = Convert.ToInt32(productId[0]); //Din lista care vine pe product_id imi iau valoarea dorita
                    s.IdStorage = 1;
                    s.StockQuantity = Convert.ToDouble(stc["quantity"]);
                    s.Rest = Convert.ToDouble(stc["quantity"]);
                    var prod = lstProduct.FirstOrDefault(
                        k => Convert.ToInt32((k as Dictionary<string, object>)["id"]) == Convert.ToInt32((stc["product_id"] as List<object>)[0])) as Dictionary<string, object>;
                    var prodTemplate =
                        lstProdTemplate.FirstOrDefault(
                            k => Convert.ToInt32((k as Dictionary<string, object>)["id"]) ==
                                 Convert.ToInt32((prod["product_tmpl_id"] as List<object>)[0])) as Dictionary<string, object>;
                    if (prodTemplate != null)
                        s.Price = Convert.ToDouble(prodTemplate["list_price"]);
                    s.Batch = "NoBatch"; // Provizoriu
                    s.Date = Convert.ToDateTime(stc["in_date"]);
                    s.ExpireDate = Convert.ToDateTime(stc["in_date"]); // Provizoriu
                    s.IdCustomerSuplier = Convert.ToInt32(stc["owner_id"]);
                    s.Id = 0; //if (Id == 0) act = insert
                    MessageStruct result = s.Save();
                    if (result.HasErrors)
                    {
                        return result.Message;
                    }
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
