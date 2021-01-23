    public class Foo {
      public string Bar { get; set; }
    }
    
    // ... in the controller
    public ActionResult Save() {
      var myFoo = new Foo();
      TryUpdateModel(myFoo);
    }
