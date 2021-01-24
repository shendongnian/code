    public class PartialDelegates:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<string> Avengers = new List<string>();
            Avengers.AddRange(new[] { "Spiderman", "Iron Man", "Dr. Stange", "The Hulk" });
            return View(Avengers);
        }
    }
