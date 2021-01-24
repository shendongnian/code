    namespace Testy20161006.Controllers
    {
        public class Campus
        {
            public int Id { get; set; }
            public string CampusName { get; set; }
        }
        public class AneleViewModel
        {
            public IList<Campus> Campuses { get; set; }
        }
        public class HomeController : Controller
        {
            [HttpPost]
            public string Tut155(long? campusId)
            {
                List<string> employees = new List<string>();
                switch (campusId)
                {
                    case 1:
                        employees.Add("John DeVry");
                        employees.Add("Tim DeVry");
                        employees.Add("Phil DeVry");
                        break;
                    case 2:
                        employees.Add("John ASU");
                        employees.Add("Tim ASU");
                        employees.Add("Phil ASU");
                        break;
                    case 3:
                        employees.Add("John UofA");
                        employees.Add("Tim UofA");
                        employees.Add("Phil UofA");
                        break;
                    default:
                        break;
                }
                return JsonConvert.SerializeObject(employees);
            }
            public ActionResult Tut155(int? id)
            {
                AneleViewModel vm = PopulateCampuses();
                return View(vm);
            }
            private static AneleViewModel PopulateCampuses()
            {
                AneleViewModel vm = new AneleViewModel();
                vm.Campuses = new List<Campus>();
                vm.Campuses.Add(new Campus { CampusName = "DeVry", Id = 1 });
                vm.Campuses.Add(new Campus { CampusName = "ASU", Id = 2 });
                vm.Campuses.Add(new Campus { CampusName = "UofA", Id = 3 });
                return vm;
            }
