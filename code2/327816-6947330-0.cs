    public List<dynamic> LoadData(int id)
    {
      var data = from f in db.Foo
                 from b in db.Bar.Where(x => x.Id == f.BarId).DefaultIfEmpty()
                 where f.SomeProperty == id
                 select new
                 {
                   SomeProperty = f.Something,
                   AnotherProperty = b.SomethingElse
                 };
      return data.Cast<dynamic>().ToList();
    }
