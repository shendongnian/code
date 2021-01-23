      public IEnumerable<CustInfo> SaveCustdata(CustInfo cust)
            {
                try
                {
                    var customerinfo = new CustInfo
                    {
                        Name = cust.Name,
                        AccountNo = cust.AccountNo,
                        Address = cust.Address
                    };
                    List<CustInfo> custlist = new List<CustInfo>();
                    custlist.Add(customerinfo);
                    return custlist;
                }
                catch (Exception)
                {
                    return null;
                }
            }
