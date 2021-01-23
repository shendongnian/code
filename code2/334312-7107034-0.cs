    public class Foo
    {
      public int ID { get; set; }
      public string Name { get; set; }
    
      [IgnoredField]
      public List<Bar> Bars { get; set; }
    
      [AdditionalInit]
      private void LoadBars(IDataStore dstore)
      {
        Bars = dstore.Query<Bar>().Where(r=> r.Foo = this.ID).ToList();
      }
    }
