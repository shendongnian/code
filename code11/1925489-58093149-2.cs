    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace DataTablesExample.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
    
            public JsonResult get_date()
            {
                List<Company1> listcomp = new List<Company1>();
    
                //This is how you are setting your company list. I will show you a basic example by adding hardcoded values
                //DataSet ds = db2layer.show_data();
    
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    listcomp.Add(new Company1
                //    {
                //        CompanyID = Convert.ToInt32(dr["CompanyID"]),
                //        CompanyName = dr["CompanyName"].ToString(),
                //        CompanyCode = dr["CompanyCode"].ToString(),
                //        Wecare_companyId = Convert.ToInt32(dr["Wecare_companyId"]),
                //        LicenseCount = Convert.ToInt32(dr["LicenseCount"]),
                //        active = Convert.ToBoolean(dr["active"]),
                //        ModifiedBy = Convert.ToInt32(dr["ModifiedBy"]),
                //        Lastmodifiedon = Convert.ToDateTime(dr["Lastmodifiedon"])
                //    });
                //}
    
                listcomp.Add(new Company1
                {
                    CompanyID = 1,
                    CompanyName = "Company 1",
                    CompanyCode = "C1",
                    Wecare_companyId = 1,
                    LicenseCount = 1,
                    active = true,
                    ModifiedBy = 1,
                    Lastmodifiedon = DateTime.Now,
                    Lastmodifiedonstring = DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)
                });
    
                listcomp.Add(new Company1
                {
                    CompanyID = 2,
                    CompanyName = "Company 2",
                    CompanyCode = "C2",
                    Wecare_companyId = 2,
                    LicenseCount = 2,
                    active = true,
                    ModifiedBy = 1,
                    Lastmodifiedon = DateTime.Now,
                    Lastmodifiedonstring = DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)
                });
    
                listcomp.Add(new Company1
                {
                    CompanyID = 3,
                    CompanyName = "Company 3",
                    CompanyCode = "C3",
                    Wecare_companyId = 1,
                    LicenseCount = 3,
                    active = true,
                    ModifiedBy = 1,
                    Lastmodifiedon = DateTime.Now,
                    Lastmodifiedonstring= DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture)
                });
                var data = listcomp;
                return Json(listcomp, JsonRequestBehavior.AllowGet);
            }
        }
    }
