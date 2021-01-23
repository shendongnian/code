        // private class members, creating new arrays
        private int [] AcctNumber = new int[5]; 
        private double [] AcctBalance = new double[5];
        private string [] LastName = new string[5];
 
        
        public void fillAccounts()//fill arrays with user input
        {
            int x = 0;
            for (int i = 0; i < AcctNumber.Length; i++)
            {
                Console.Write("Enter account number: ");              
                AcctNumber[x] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter account balance: ");
                AcctBalance[x] = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter account holder last name: ");
                LastName[x] = Convert.ToString(Console.ReadLine());
                x++;
            } 
 
        }
 
        public void searchAccounts() //search account method to be called later in main()
        {
            int accountNum = 0;
            bool isValid = false;
            int x = 0;
 
            Console.Write("Please enter account number to search for: ");
            accountNum = Convert.ToInt32(Console.ReadLine());
 
            
            while (x < AcctNumber.Length && accountNum != AcctNumber[x])
                ++x;
			if(x != AcctNumber.Length)
			{
			isValid = true;
			}
			if(isValid){
			Console.WriteLine("AcctNumber: {0}		Balance: {1:c}	Acct Holder: {2}", AcctNumber[x], AcctBalance[x], LastName[x]);
            }
			else{  
                Console.WriteLine("You entered an invalid account number"); 
			}                    
        }
 
        public void averageAccounts()//averageAccounts method to be store for later use
        {
            // compute and display average of all 5 bal as currency use length.
            int x = 0;
            double balanceSum = 0;
            double Avg = 0;
 
            for (x = 0; x < 5; x++ )
            {
                balanceSum = balanceSum + AcctBalance[x];
            }
            Avg = (balanceSum / x);
            Console.WriteLine("The average balance for all accounts is {0:c}", Avg);
        } 
 
    } //end public class Accounts
 
 
