    public class MyData
    {
      public string SomeProperty { get; set; }
      public string AnotherProperty { get; set; }
    }
    public List<MyData> LoadData(int id)
    {
      var data = from f in db.Foo
                 from b in db.Bar.Where(x => x.Id == f.BarId).DefaultIfEmpty()
                 where f.SomeProperty == id
                 select new MyData()
                 {
                   SomeProperty = f.Something,
                   AnotherProperty = b.SomethingElse
                 };
      return data.ToList();
    }
