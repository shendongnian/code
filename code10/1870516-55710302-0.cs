	public void DoDeposit()
	{
		Console.Write("Please enter the amount you would like to deposit:");
		decimal DepositAmount;
		DepositAmount = Convert.ToDecimal(Console.ReadLine());
		bool response;
		
		var account = new Account();   // Instantiate object
		response = Convert.ToBoolean(account.Deposit(DepositAmount));  // Use instantiated object
	}
