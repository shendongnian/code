    public class HomeController : Controller
       {
          
          private static TestViewModel InitTestVM()
          {
             //People for dropdownlist 1
             var db = new List<People>();//peopleRepository.People;
             db.Add(new People { Id = 1, Name = "Name 1" });
             db.Add(new People { Id = 2, Name = "Name 2" });
             var query = db.Select(c => new { c.Id, c.Name });
    
             //Elements for dropdownlist 2
             var list = new Dictionary<string, string> { { "1", "Name" }, { "2", "Address" }, { "3", "Zip" } };
    
             TestViewModel testVM = new TestViewModel
             {
                People = new SelectList(query.AsEnumerable(), "Id", "Name"),
                Elements = new SelectList(list, "Key", "Value")
             };
             return testVM;
          }
    
          public ActionResult Index()
          {
             return View(InitTestVM());
          }
    
          // This part is what I'm confused about.
          [AcceptVerbs(HttpVerbs.Post)]
          public ActionResult Index(TestViewModel testVM)
          {
             var vm = InitTestVM();
             if (ModelState.IsValid && testVM != null)
             {
                ModelState.Clear();
                // Output from persistent storage query
                //var da = new DatabaseAccess(people, elements);
                vm.Results = "sfdfsdfsdfsdfsdfsdfsdfsdf";//da.Execute();
                vm.SelectedElementId = testVM.SelectedElementId;
                vm.SelectedPeopleId = testVM.SelectedPeopleId;
                return View(vm);
             }
             return View(vm);
          }
       }
