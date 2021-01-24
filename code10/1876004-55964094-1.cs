        string strQuery = "Select Count(*) From Customer";
        
        string custCount = qboAccess.GetCustomersCount(qboInz.QboServiceContext, strQuery);
        
        List<Customer> customers = new List<Customer>();
        int maxSize = 0;
        int position = 1;
        int count = Convert.ToInt32(custCount);
        do
         {
          var custList = qboAccess.GetAllQBOEntityRecords(qboInz.QboServiceContext, new 
          Customer(), position, 1000);
          customers.AddRange(estList);
          maxSize += custList.Count();
          position += 1000;
          } while (count > maxSize);
        foreach (var cust in customers)
                    {
        CustomersViewModel customersViewModel = new CustomersViewModel();
        customersViewModel.Id = cust.Id;
        customersViewModel.CustomerID = cust.Id;
        customersViewModel.CustomerName = cust.FullyQualifiedName;
        customersViewModel.Phone =cust?.PrimaryPhone?.FreeFormNumber;
        customersViewModel.Email = cust?.PrimaryEmailAddr?.Address;
        customersViewModel.OpeningBalance = cust.Balance;
        EbizSession.Current?.customersData.Add(customersViewModel);
    }
 
    return Json(EbizSession.Current?.customersData,JsonRequestBehavior.AllowGet);
