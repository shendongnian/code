        [HttpGet]
        public ActionResult ReportDetailed()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult ReportDetailed(DetailedViewModel detailedviewmodel)
        {
            var status = "error";
            var message = "";
            try
            {
                string commodity = detailedviewmodel.commodity;
                string commoditytype = detailedviewmodel.commodityType;
                string department = detailedviewmodel.department;
                List<string> purchasereporttypes = detailedviewmodel.purchaseReportTypes;
                string repository = detailedviewmodel.repository;
                string startdate = detailedviewmodel.dateValue_2;
                string enddate = detailedviewmodel.dateValue_1;
                string commdoityname = detailedviewmodel.commodityName;
                // your code here ...
                status = "success";                
                return Json(new { status, detailedviewmodel } , JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Json(new { status, message }, JsonRequestBehavior.AllowGet);
            }            
        }
