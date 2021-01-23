    // Controller
    public class Restaurant:Controller
    {
        public ActionResult Search()
        {
             return View();  // Forgot the provide a Model here.
        }
    }
    // Razor view 
    @foreach (var restaurantSearch in Model.RestaurantSearch)  // Throws.
    {
    }
    
