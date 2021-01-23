    DateTime dateA = DateTime.Now;
    DateTime dateB = DateTime.Now.AddHours(1).AddMinutes(10).AddSeconds(14);
    Console.WriteLine("Date A: {0}",dateA.ToString("o"));
    Console.WriteLine("Date B: {0}", dateB.ToString("o"));
    Console.WriteLine(String.Format("Comparing objects A==B? {0}", dateA.Equals(dateB)));
    Console.WriteLine(String.Format("Comparing ONLY Date property A==B? {0}", dateA.Date.Equals(dateB.Date)));
    Console.ReadLine();
