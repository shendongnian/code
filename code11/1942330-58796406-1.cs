    public static implicit operator CustResult(Cust cust)
    {
        return new CustResult()
        {
            custname = cust.custname,
            company = cust.company
        }
    }
