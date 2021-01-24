     public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            if (Request.Files["ChequeFile"].ContentLength > 0)
            {
                String path = "~/Content/";
                var fileName = Path.GetFileName(Request.Files["ChequeFile"].FileName);
                Random rnd = new Random();
                int rndnumber = rnd.Next(1, 9999999);
                var filepath = Path.Combine(path, rndnumber + "" + fileName);
                if (System.IO.File.Exists(filepath))
                { System.IO.File.Delete(filepath); }
                Request.Files["ChequeFile"].SaveAs(Server.MapPath(filepath));
                return Json("File Successfully Upload via ajax.");
            }
            else
            {
                return Json("File Must Be Required");
            }
        }
