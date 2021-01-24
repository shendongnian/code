    public class FileAccountRepository : IAccountRepository
    {
        List<Account> accounts = new List<Account>();
    
        public void GetUsers() {
            string path = @".\Accounts.txt";
            string[] rows = File.ReadAllLines(path);
    
    
            for (int i = 1; i < rows.Length; i++)
            {
                Account data = new Account();
                string[] columns = rows[i].Split(',');
    
                data.AccountNumber = columns[0];
                data.Name = columns[1];
                data.Balance = Decimal.Parse(columns[2]);
                if (columns[3] == "F")
                {
                    data.Type = AccountType.Free;
                }
                else if (columns[3] == "B")
                {
                    data.Type = AccountType.Basic;
                }
                else if (columns[3] == "P")
                {
                    data.Type = AccountType.Premium;
                }
    
                accounts.Add(data);
            }
        }
