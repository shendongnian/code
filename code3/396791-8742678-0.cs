    @model string
    @if (!string.IsNullOrWhiteSpace(Model) && Model == "Bar") {
      //Do something when Foo=Bar (like http://server/route?Foo==Bar)
      <html class="bar-class">
    }
    else {
      //Normal html tag
      <html>
    }
    
    public ActionResult Route(string foo){
      return View(foo);
    }
