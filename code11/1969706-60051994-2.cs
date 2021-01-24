    public class BudgetItem {
      public int Id { get; set; }
      private DateTime _Date { get; set; }
      public string Date => _Date.ToShortDateString();
      public string Type { get; set; }
      public string Name { get; set; }
      public decimal Expense { get; set; }
      public decimal Income { get; set; }
      public decimal Balance => Income - Expense;
    
      public BudgetItem(int id, DateTime date, string type, string name, decimal expense, decimal income) {
        Id = id;
        _Date = date;
        Type = type;
        Name = name;
        Expense = expense;
        Income = income;
      }
    }
