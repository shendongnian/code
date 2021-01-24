    public class DataClass
    {
    
        public Guid Item1 { get; set; }
        public int Item2 { get; set; }
        public string Item3 { get; set; }
    }
   
    List<DataClass> requestItemActions = objectContext.ObjectContext.Translate<DataClass>(reader).ToList();
