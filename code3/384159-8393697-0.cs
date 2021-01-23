        private XDocument BuildDocument()
        {
            var myAmount = new XElement("OrderNumber", 12345);
            var myNumber = new XElement("OrderAmount");
            var myOrder = new XElement("Order", myAmount, myNumber);
            var myOrders = new XElement("Orders", myOrder);
            return new XDocument(myOrders);
        }
        private class Order
        {
            public int OrderNumber { get; set; }
            public decimal? OrderAmount { get; set; }
        }
        [TestMethod]
        public void TestMethod()
        {
            var myDoc = BuildDocument();
            List<Order> myOrders = (from orders in myDoc.Descendants("Order")
                                   select new Order
                                   {
                                       OrderNumber = (int)orders.Element("OrderNumber"),
                                       OrderAmount = GetAmount(orders.Element("OrderAmount"))
                                   }).ToList<Order>();
        }
        private static decimal? GetAmount(XElement e)
        {
            if (e == null || string.IsNullOrEmpty(e.Value))
            {
                return 0.0M;
            }
            return (decimal?)e;
        }
