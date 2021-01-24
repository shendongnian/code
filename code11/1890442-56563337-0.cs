    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using My_App.Models;
    
    namespace My_App.Controllers
    {
        public class RegistrationController : Controller
        {
    [HttpPost]
            public ActionResult Registration()
            {
                Database1 db = new Database1();
                  List<MyClass> MyClassList = new List<MyClass>();
    
                var details = (from c in db.Car
                               join u in db.User on c.id_car equals u.id_car
                               select new { c.id_car, c.id_city, c.car_name, u.id_user,u.name_user }).ToList();
                foreach (var item in details)
                {
                    MyClass mC = new MyClass();
                    mC.id_car = item.id_car;
                    mC.id_city = item.id_city;
                    mC.car_name = item.car_name;
                    mC.id_user = item.id_user;
                    mC.name_user = item.name_user;
                    MyClassList.Add(mC); MyClassList.Add(mC);
                  }
    
               return View(MyClassList);
            }
