    public class Person {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public ActionResult Index() {
        var people = new List<Person>() { 
	        new Person { Name = "Albert Adams", Email = "albert@email.com" },
    	    new Person { Name = "Bob Becker", Email = "bob@email.com" },
    	    new Person { Name = "Charles Charles", Email = "charles@email.com" }
    	};
    	ViewData["People"] = people;
    	ViewResult viewResult = View();
    	viewResult.ViewEngineCollection = new ViewEngineCollection { new NustacheViewEngine() };
    	return viewResult;
    }
