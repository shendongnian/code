            [HttpPost]
        public ActionResult Index(int CasinoID, DateTime Date)
        {
                var id = Int32.Parse(Request.Form["CasinoID"].ToString());
                var model = TRBL.GetTransactionTestsData(id, Date);
                model.TerminalReceiptPostData = TRBL.GetCasinosDDL();
                return View(model);
        }
