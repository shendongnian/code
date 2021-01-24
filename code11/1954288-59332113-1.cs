        public enum AccountType
        {
            Free,
            Basic,
            Premium
        }
**this is your Account class**
  1. This has built in Account method that will convert the string into an Account. Can be used in many different places.
  2. Has a method that converts the class to a string (comma seperated).
        public class Account
        {
            public int AccountNumber { get; set; }
            public AccountType Type { get; set; }
            public int Balance { get; set; }
            public string AccountType { get; set; }
            public Account() { }
            // Built in constructor that converts the string to account.
            public Account(string account)
            {
                List<string> accountInfo = account.Split(',').ToList();
                int.TryParse(accountInfo.FirstOrDefault(), out int accountNum);
                AccountNumber = accountNum;
                Type = (AccountType)Enum.Parse(typeof(AccountType), accountInfo.Skip(1).FirstOrDefault().Split(' ').First());
                int.TryParse(accountInfo.Skip(2).FirstOrDefault(), out int balance);
                Balance = balance;
                AccountType = accountInfo.Skip(3).FirstOrDefault();
            }
            // built in the Account the method to convert to string.
            public override string ToString()
            {
                return $"{AccountNumber},{Type.ToString()},{Balance},{AccountType}";
            }
        }
**And, save method to save a new account to existing file**
Loads the accounts in a list and validates the account does not already exists in the file. Updates it with a new account and saves it.
        public static void SaveAccount(Account account)
        {
            string path = @"C:\temp\Accounts.txt";
            (string header, List<Account> allAccounts) = LoadAccounts(path);
            if (!allAccounts.Any(x => x.AccountNumber == account.AccountNumber))
                allAccounts.Add(account);
            List<string> accountsToSave = new List<string>() { header };
            accountsToSave.AddRange(allAccounts.Select(x => x.ToString()).ToList());
            
            File.WriteAllLines(path, accountsToSave);
        }
**You can use this method to load all Accounts to memory**
        public static (string, List<Account>) LoadAccounts(string path)
        {
            var accounts = File.ReadAllLines(path);
            string header = accounts.FirstOrDefault();
            List<Account> allAccounts = new List<Account>();
            foreach (string accountInfo in accounts.Skip(1))
            {
                var accountToAdd = new Account(accountInfo);
                if (!allAccounts.Any(x => x.AccountNumber == accountToAdd.AccountNumber))
                    allAccounts.Add(accountToAdd);
            }
            return (header, allAccounts);
        }
