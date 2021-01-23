        [HttpPost]
        [ActionName("Index")]
        public ActionResult SearchRecord(FormCollection formcollection)
        {
           
            EmployeeContext employeeContext = new EmployeeContext();
            string searchby=formcollection["SearchBy"];
            string value=formcollection["Value"];
            if (formcollection["SearchBy"] == "Gender")
            {
                List<MvcApplication1.Models.Employee> emplist = employeeContext.Employees.Where(x => x.Gender == value).ToList();
                return View("Index", emplist);
            }
            else
            {
                List<MvcApplication1.Models.Employee> emplist = employeeContext.Employees.Where(x => x.Name == value).ToList();
                return View("Index", emplist);
            } 
            
        }
