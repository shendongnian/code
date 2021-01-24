    static void Main(string[] args)
    {
      List<SomeClass> scl = new List<SomeClass>();
      List<OtherClass> ocl = new List<OtherClass>();
      foreach (var item in scl)
        item.FrequencyA = ocl.Where(i => i.Text == item.Kanji).FirstOrDefault()?.Code ?? null;
    }
    // sample classes that reflect relevant properties
    public class SomeClass
    {
      public string FrequencyA { get; set; }
      public string Kanji { get; set; }
    }
    public class OtherClass
    {
      public string Code { get; set; }
      public string Text { get; set; }
    }
