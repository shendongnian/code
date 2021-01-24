    [HttpGet]
    public ActionResult MyGetMethod([FromQuery]Foo myParam) {...}
    
    public class Foo {
       public string Address {get; set;}
       public string Zip {get; set;}
       public int Width {get; set;}
    }
