    public class MyPageModel : PageModel
    {
        public List<MyClass> Entities { get; set; } = new List<MyClass>();
        public List<MyClass> EntitiesWithNoId => Entities.Where(e => e.ID == 0);
        // blah blah
    }
