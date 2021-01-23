    var orders = new orders
    {
        order = new ordersOrder
        {
            ordersID = 1,
            ordersTotal = 1,
            prod = new ordersOrderProd[]
            {  
                new ordersOrderProd
                {
                    productCount = 1, 
                    productDiscount = 8.4, 
                    productName = "Widget", 
                    productNumber = 987987, 
                    productPrice = 78.9, 
                    productPricePromo = 68.75
                }
            }
        }
    };
    
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(orders));
    TextWriter writer = new StreamWriter(".\\Family.xml");
    xmlSerializer.Serialize(writer, orders);
    writer.Close();
