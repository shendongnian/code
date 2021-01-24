c#
	var transactions = new List<Transaction>()
	{
		new Transaction() {
 		    TransactionAmount = 3334.38,
		    TransactionDate = new DateTime(DateTime.UtcNow.AddYears(-2).Year, 1, 20),
		    TransactionType = TransactionType.Deposit
		},
		new Transaction() {
 		    TransactionAmount = -3334.38,
			TransactionDate = new DateTime(DateTime.UtcNow.AddYears(-2).Year, 1, 21),
			TransactionType = TransactionType.Withdraw
		},
		new Transaction() {
			TransactionAmount = 1000.23,
			TransactionDate = new DateTime(DateTime.UtcNow.AddYears(-2).Year, 1, 25),
			TransactionType = TransactionType.Deposit
		},
	};
 
	var data = from t in transactions
 			   group t by new {t.TransactionDate.Year , t.TransactionDate.Month} into g
			   select new {
			     tBalance = g.Sum(x => x.TransactionAmount),
				 g.First().TransactionDate.Month,
				 g.First().TransactionDate.Year
			   };
// ----------------------
// result :
// tBalance 1000.23
// Month 1
// Year 2018
   
