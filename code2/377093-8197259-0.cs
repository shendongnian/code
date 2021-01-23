    var ser = new XmlSerializer(typeof(TradeDoublerProducts));
            TradeDoublerProducts tradeDoublerProducts;
            using (XmlReader reader = XmlReader.Create(myXml))
            {
                tradeDoublerProducts = (TradeDoublerProducts) ser.Deserialize(reader);
            }
            IEnumerable<TradeDoublersProductsProduct> model = tradeDoublerProducts.Items;
            AddModelToProducts(model);
