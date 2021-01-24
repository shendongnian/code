    var AllCustomerServices = _context.CustomerServices.Where(w=>w.strUserID == Session["userID"].ToString()).ToList();
        
        if (AllCustomerServices.Any())
        {
            List<CustomerServices> cstSrvs = new List<CustomerServices>();
            cstSrvs.AddRange(AllCustomerServices);
        }
