     IEnumerable<Account> container = await ExecuteCustomersQueryAsync();
            try
            {
                foreach (Account cust in container)
                {
                    Console.WriteLine("Customer Name: {0}, Acc No.: {1}", cust.Name, cust.AccountNumber);                   
                }
            }
            catch (DataServiceQueryException ex)
            {
                    throw new ApplicationException("An error occurred during query execution.", ex);
            }
