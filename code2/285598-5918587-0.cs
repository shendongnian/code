    public void messageParser()
        {
            int i = 0;
            bool readingBids = false;
            bool readingOffers = false;
            decimal price=0;
            int qty = 0;
            StreamReader sr = new StreamReader("..\\..\\sampleResponse.xml");
            XmlReader xmlReader = XmlReader.Create(sr);
            DateTime startTime = DateTime.Now;
            while (xmlReader.Read())
            {
                #region reading bids
                if (xmlReader.IsStartElement("bids"))
                {
                    readingBids = true; 
                    readingOffers = false; 
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "bids")
                {
                    readingBids = false;
                    readingOffers = false;
                }
                if (readingBids == true)
                {
                    if (xmlReader.IsStartElement("price"))
                        price = xmlReader.ReadElementContentAsDecimal();
                    if (xmlReader.IsStartElement("quantity"))
                    {
                        qty = xmlReader.ReadElementContentAsInt();
                        OnPricePointReceived(this, new MessageEventArgs(price, qty, "bid"));
                    }
                }
                #endregion
                #region reading offers
                if (xmlReader.IsStartElement("offers"))
                { 
                    readingBids = false; 
                    readingOffers = true; 
                }
                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "offers")
                {
                    readingBids = false;
                    readingOffers = false;
                }
                if (readingOffers == true)
                {
                    if (xmlReader.IsStartElement("price"))
                        price = xmlReader.ReadElementContentAsDecimal();
                    if (xmlReader.IsStartElement("quantity"))
                    {
                        qty = xmlReader.ReadElementContentAsInt();
                        OnPricePointReceived(this, new MessageEventArgs(price, qty, "offer"));
                    }
                }
                #endregion
            }
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("time: {0}",stopTime - startTime);
            Console.ReadKey();
        }
    }
