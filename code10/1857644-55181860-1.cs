    public class Boo:IDataWithName 
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
    public class BooContainer: IDataWithNameContainer<Boo>
    {
        public IList<Boo> DataList { get; set; }
    }
