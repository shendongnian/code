        [HttpGet]
        public ActionResult Create()
        {
            EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
            Employee emp = new Employee()
            {
                AvailableHobbies = new MultiSelectList(objemployee.GetHobby(), "Id", "Hobby")
            };
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            var selectedHobbies = emp.SelectedHobbies;
            ...
            return RedirectToAction("Index");
        }
