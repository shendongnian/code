    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Select> selectList = new List<Select>()
            {
                new Select(){  SelectId=1, Name="aaa"},
                new Select(){  SelectId=2, Name="bbb"},
                new Select(){  SelectId=3, Name="ccc"},
                new Select(){  SelectId=4, Name="ddd"},
            };
            ViewBag.SList = new SelectList(selectList, "SelectId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Example(TestModel model)
        {
            var selectedValue = model.Select.SelectId;// Or model.Name
            //do your stuff...
        }
