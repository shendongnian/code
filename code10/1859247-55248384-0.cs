    public class Account
    {
        protected string name;
        protected string birthdate;
        protected string address;
        protected double balance;
        protected string status;
        protected string type;
    
        public Account(string customerName, string customerBirthdate, string customerAddress, int customerBalance)
        {
            this.name = customerName;
            this.birthdate = customerBirthdate;
            this.address = customerAddress;
            this.balance = customerBalance;
            this.status = "Ok";
            this.type = "Basic";
        }
    
        public void customerDetails()
        {
            Console.WriteLine("Name: {0}, Birthdate: {1}, Address: {2}", name, birthdate, address);
        }
    
        public void accountDetails()
        {
            Console.WriteLine("Balance: £{0}, Account Status: {1}, Account Type: {2}", Math.Round(balance, 2), status, type);
        }
    
        private void updateStatus()
        {
            if (balance < 0)
            {
                status = "Overdrawn";
            }
            else if (balance > 0)
            {
                status = "Ok";
            }
        }
    
        public void deposit(int amount)
        {
            balance += amount;
            updateStatus();
        }
    
        public void withdraw(int amount)
        {
            balance -= amount;
            updateStatus();
        }
    }
    
    public class Savings : Account
    {
        public Savings(string customerName, string customerBirthdate, string customerAddress, int customerBalance) : base (customerName, customerBirthdate, customerAddress, customerBalance)
        {
            base.name = customerName;
            base.birthdate = customerBirthdate;
            base.address = customerAddress;
            base.balance = customerBalance;
            base.status = "Ok";
            base.type = "Basic";
        }
    }
