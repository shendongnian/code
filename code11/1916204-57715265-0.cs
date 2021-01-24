    // define classes
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public string Name { get; set; }
    }
    public class TransactionHistoryQuery
    {
        public DateTime? DateFrom { get; set; } = null;
        public DateTime? DateTo { get; set; } = null;
        public string Name { get; set; } = null;
    }
    // prep test data
    IList<Transaction> transactions = new List<Transaction>();
    transactions.Add(new Transaction() { Name = "T1",TransactionDate = new DateTime(2010,10,19)});
    transactions.Add(new Transaction() { Name = "T2", TransactionDate = new DateTime(2015, 5, 13) });
    transactions.Add(new Transaction() { Name = "T3", TransactionDate = new DateTime(2018, 12, 3) });
    // prepare query
    TransactionHistoryQuery q = new TransactionHistoryQuery();
    q.DateFrom = new DateTime(2017,1,1);
    q.Name = "T";
    // perform query and 'ignore' the null values in your query logic using conditions with parenthesis 
    var result = 
        transactions.Where(t => (
                     (t.TransactionDate >= q.DateFrom  && t.TransactionDate <= q.DateTo) ||
                     (t.TransactionDate >= q.DateFrom && q.DateTo == null) ||
                     (q.DateFrom == null && t.TransactionDate <= q.DateTo)) &&
                     (t.Name.Contains((q.Name ?? string.Empty)) || q.Name == null)
                     ).ToList();
    // results =  { Name = "T3", TransactionDate = new DateTime(2018, 12, 3) }
