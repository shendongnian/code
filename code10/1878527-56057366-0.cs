    static void Main(string[] args)
    {
      List<Company> companies = new List<Company>();
      companies.OrderBy(c => c.MainName == null ? c.ChildName : c.MainName);
    }
    
    class Company
    {
      public string CompanyName { get; set; }
      public string MainName { get; set; }
      public string ChildName { get; set; }
    }
