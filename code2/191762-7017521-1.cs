    public class MainClass
    {
      [ImportMany("BirthdayJob",typeof(ITest))]
      private List<ITest> Tests { get; set; }
    
      // class definition
    }
