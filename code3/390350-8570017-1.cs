    public class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Due { get; set; }
        public string Recurrence { get; set; }
        public decimal Paid { get; set; }
        public DateTime LastPaid{ get; set; }
    }
    public class ExpenseCollection : System.Collections.Generic.List<Expense>
    {
    
    }
