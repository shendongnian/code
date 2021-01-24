        public static void ProcessCustomersLinq(List<Customer> customers)
        {
            customers?
                .Where(c => c != null && c.Accounts != null)
                .SelectMany(c => c.Accounts.Where(a => a != null))
                .ToList()
                .ForEach(a => TrimAccountNumber(a));
        }
        private static void TrimAccountNumber(Account account)
        {
            account.AccountNumber = account.AccountNumber.Trim().TrimStart(new char[] { '0' });
        }
