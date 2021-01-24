    static void Main(string[] args)
    {
	  string dump = "";
	  using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AchieveDB"].ConnectionString)){
      conn.Open();
      CashIn oCashIn = conn.Get<CashIn>(59458);
      dump = ObjectDumper.Dump(oCashIn);
      Console.WriteLine(dump);
      Console.WriteLine("Updating");
      Console.WriteLine("=========");
      oCashIn.ReconciledOn = DateTime.Now;
      dump = ObjectDumper.Dump(oCashIn);
      Console.WriteLine(dump);
      conn.Update <CashIn>(oCashIn);
    }
