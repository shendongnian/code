    using System;
    using System.Collections.Generic;
    using JTableExampleNETFramework.Models;
    using System.Web.Mvc;
    
    namespace JTableExampleNETFramework.Controllers
    {
        public class HomeController : Controller
        {
    
            public ActionResult Employee()
            {
                return View();
            }
    
            //Added as an example to populate our dummy list for employee
            [HttpPost]
            public JsonResult GetEmployeeData()
            {
                try
                {
                    //Add to our list
                    List<Employee> employeeList = new List<Employee>()
                    {
                      new Employee(){ EmployeeId =1, Name ="Bill",City="New York",Department="HR",Gender="Male",BulkUpdate=false},
                      new Employee(){ EmployeeId =2, Name ="Lindsey",City="London",Department="Finance",Gender="Female",BulkUpdate=true},
                      new Employee(){ EmployeeId =3, Name ="Rahul",City="New Delhi",Department="IT",Gender="Male",BulkUpdate=false},
                      new Employee(){ EmployeeId =4, Name ="Sameera",City="Istanbul",Department="Operations",Gender="Female",BulkUpdate=true}
                    };
    
                    //var json = JsonConvert.SerializeObject(studentList);
                    return Json(new { Result = "OK", Records = employeeList, TotalRecordCount = employeeList.Count });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
    
            [HttpPost]
            public JsonResult UpdateEmployeeData()
            {
                //Your logic to update employee data
                return Json("Updated Employee Data");
            }
    
            [HttpPost]
            public JsonResult DeleteEmployeeData()
            {
                //Your logic to delete employee data
                return Json("Delete Employee Data");
            }
    
            [HttpPost]
            public JsonResult InsertEmployeeData()
            {
                //Your logic to insert employee data
                return Json("Insert Employee Data");
            }
    
        }
    }
