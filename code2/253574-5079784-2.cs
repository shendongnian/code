    public class FooBarDetails
    {
       public string Property1 {get;set;}
       public string Property2 {get;set;}
       public Foo Foo {get;set;}
       public Bar Bar {get;set;}
    }
    var details = _repo.GetDetails(detailId);
