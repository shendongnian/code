    using(StreamReader sr = new StreamReader(fileName))
    {
        List<Employee_Record> Employees = new List<Employee_Record>();
        var lines = sr.ReadLine();
        Regex re = new Regex(@"\W?");
          MatchCollection mc = re.Matches(lines);
          int mIdx=0;
          foreach (Match m in mc){
    Console.writeline(m.Value);
        }
    // Do your logic here as you wish
    }
      
