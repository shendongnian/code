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
