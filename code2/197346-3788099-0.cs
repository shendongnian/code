     public class STLItemAvailable
        {
            private string _itemNumber;
            public string ItemNumber
            {
                get
                {
                    return _itemNumber;
                }
            }
    
            private int _tnOnHand;
            public int TNOnHand
            {
                get
                {
                    return _tnOnHand;
                }
            }
    
            private int _tnOnOrder;
            public int TNOnOrder
            {
                get
                {
                    return _tnOnOrder;
                }
            }
    
            private DateTime _tnOrderETA;
            public DateTime TNOrderETA
            {
                get
                {
                    return _tnOrderETA;
                }
            }
    
            private int _nvOnHand;
            public int NVOnHand
            {
                get
                {
                    return _nvOnHand;
                }
            }
    
            private int _nvOnOrder;
            public int NVOnOrder
            {
                get
                {
                    return _nvOnOrder;
                }
            }
    
            private DateTime _nvOrderETA;
            public DateTime NVOrderETA
            {
                get
                {
                    return _nvOrderETA;
                }
            }
    
            public STLItemAvailable()
            {
                //
                // TODO: Add constructor logic here
                //
            }
    
            public STLItemAvailable(string APIKey, string ItemNumber)
            {
                GetItemAvailable gia = new GetItemAvailable();
                ItemsArray ia = gia.CallGetItemAvailable(APIKey, ItemNumber);
    
                XmlElement[] XEArray = ia.Any;
                XmlNode n = XEArray[0];
    
                int testn = 0;
                DateTime testd;
                foreach (XmlNode xn in n.ChildNodes)
                {
                    switch (xn.Name)
                    {
                        case "item_id":
                            this._itemNumber = xn.InnerText;
                            break;
                        case "tn_onhand":
                            int.TryParse(xn.InnerText, out testn);
                            this._tnOnHand = testn;
                            break;
                        case "tn_onorder":
                            int.TryParse(xn.InnerText, out testn);
                            this._tnOnOrder = testn;
                            break;
                        case "tn_onorder_eta":
                            DateTime.TryParse(xn.InnerText, out testd);
                            this._tnOrderETA = testd;
                            break;
                        case "nv_onhand":
                            int.TryParse(xn.InnerText, out testn);
                            this._nvOnHand = testn;
                            break;
                        case "nv_onorder":
                            int.TryParse(xn.InnerText, out testn);
                            this._nvOnOrder = testn;
                            break;
                        case "nv_onorder_eta":
                            DateTime.TryParse(xn.InnerText, out testd);
                            this._nvOrderETA = testd;
                            break;
