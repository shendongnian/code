    FSServiceOrder currentServiceOrder = this.Base.ServiceOrderRecords.Current;
    
    if (currentServiceOrder != null && currentServiceOrder.CustomerID != null)
    {
                    Customer cust = PXSelect<Customer, Where<Customer.bAccountID, Equal<Required<Customer.bAccountID>>>>.Select(this.Base, currentServiceOrder.CustomerID);
                    if (cust == null)
                    {
                        string exc = "Invalid customer ID";
                        throw new PXException(exc);
                    }
    }
