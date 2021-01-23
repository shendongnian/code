    return Customers.GetQuery().
                Where(x => x.CompanyId == companyId).
            OrderBy(x=> IsNumeric(x.customer_name) ? 1 : 0);
    
    public bool IsNumeric(string value)
    {
         int result;
         return int.TryParse(value, out result);
    }
