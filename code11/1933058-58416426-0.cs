	public class Book_Transaction
	{
		public int Id { get; set; }
		public int BookId { get; set; }
		public int CustomerId { get; set; }
		public double RatingStar { get; set; }
	}
	var bookTransactions = new List<Book_Transaction>() {
		new Book_Transaction {
			Id = 1,
			BookId = 1,
			CustomerId = 1,
			RatingStar = 4.5
		}, new Book_Transaction {
			Id = 2,
			BookId = 2,
			CustomerId = 1,
			RatingStar = 4
		}, new Book_Transaction {
			Id = 3,
			BookId = 1,
			CustomerId = 2,
			RatingStar = 5
		},new Book_Transaction {
			Id = 4,
			BookId = 2,
			CustomerId = 2,
			RatingStar = 3.5
		},new Book_Transaction {
			Id = 5,
			BookId = 1,
			CustomerId = 3,
			RatingStar = 4
		}};
