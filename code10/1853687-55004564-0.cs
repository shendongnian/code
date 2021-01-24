    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    namespace Test_MVC.Controllers
    {
        public class TestController : Controller
        {
            [HttpGet]
            public ActionResult Index()
            {
                // Create some data for initial display
                var packageModels1 = new[] {
                    new PackageDetailsViewModel { packages_id = 101, package_title = "Order 101", is_selected = false },
                    new PackageDetailsViewModel { packages_id = 102, package_title = "Order 102", is_selected = true },
                    new PackageDetailsViewModel { packages_id = 103, package_title = "Order 103", is_selected = false }
                };
                var packageModels2 = new[] {
                    new PackageDetailsViewModel { packages_id = 201, package_title = "Order 201", is_selected = false },
                    new PackageDetailsViewModel { packages_id = 202, package_title = "Order 202", is_selected = false }
                };
                var couponModels = new[] {
                    new Provider_Coupon_FullViewModel { cid = 1, crid = 2, opr_user = "John", pid = 4, PackageDetails = packageModels1.ToList() },
                    new Provider_Coupon_FullViewModel { cid = 7, crid = 8, opr_user = "Beth", pid = 6, PackageDetails = packageModels2.ToList() }
                };
                return View(couponModels.ToList());
            }
            [HttpPost]
            public ActionResult Index(List<Provider_Coupon_FullViewModel> model)
            {
                // Pass whatever was posted & parsed right back into the view for verification
                return View(model);
            }
        }
    }
