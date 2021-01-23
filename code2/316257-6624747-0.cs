    public class SomeClass {
        public Comm Comm { get; set; }
        public IList<String> SIList { get; set; }
        public Int32 Count { get; set; }
    }
    var si = _repository.GetAllByDate(date);
    var cs = from s in si
             group s by s.Name into g
             select new SomeClass { Comm = g.Key, SIList = g.ToList(), Count = g.Count() };
