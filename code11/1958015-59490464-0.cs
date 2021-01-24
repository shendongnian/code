    public class Goods
    {
        public string Name { get; set; }
    }
    public class GoodsList : List<Goods>
    {
        public string Name { get; set; }
        public List<Goods> GoodsAll => this;
    }
    public class Person
    {
        public string Name { get; set; }
        public List<GoodsList> List;
    }
