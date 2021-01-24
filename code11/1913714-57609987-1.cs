        public ActionResult PrintVisitorPass(string id)
        {
           
            var visitList = (from visitor in db.VisitorDetails
								 where visitor.invoiceid == id
								select visitor).ToList();
   
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "VisitorPass2.rpt"));
            rd.SetDataSource(visitList);
          
            try
            {
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
                return RedirectToAction("ActionName", "ControllerName", new { id = id });
            }
            catch (Exception ex) { return RedirectToAction(ex.ToString()); }
        }
		
