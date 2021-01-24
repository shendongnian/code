    1. First I get the count of all the customers 
    2. Then I get all the customers in chunks and the chunk size is 1000 
    3. Create a List for customers. 
    4. Define 3 integer type variables for counting. 
    5. After that use do-while loop  
    6. Add all the customers are added to the main customer list
        
            string strQuery = "Select Count(*) From Customer";
            string custCount = qboAccess.GetCutomerCount(qboInz.QboServiceContext, strQuery);
            List<qboData.Customer> customers = new List<Customer>();
            int maxSize = 0;
            int position = 1;
            int count = Convert.ToInt32(custCount);
            do
            {
              var custList = qboAccess.GetAllQBOEntityRecords(qboInz.QboServiceContext, new Customer(), position, 1000);
              customers.AddRange(custList);
              maxSize += custList.Count();
              position += 1000;
            } while (count > maxSize);
