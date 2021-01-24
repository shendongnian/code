    [HttpGet]
    public ActionResult Index(int? search)
            {
                // check search null before query
    
                var storingen = from s in db.tbl_Storing
                                select s;
                if (search != null)
                {
                    storingen = storingen.Where(s => s.postcode_nr == (search));
                }
                return View(storingen.ToList());
    }
