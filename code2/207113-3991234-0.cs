var category;
using (MyEntities context = new MyEntities()) {
    category = _context.Categories.First();
}
foreach (var e in cateogry.Expenses)
      Console.WriteLine("Expense:{0}", e.Amount.ToString("C"));
}
