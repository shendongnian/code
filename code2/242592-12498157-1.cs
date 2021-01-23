            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Index(FormCollection fc)
            {   
                string a = fc["hdn_1"].ToString(); // if you know for sure that it will have a value.
                string lbl_1 = null;
    
                foreach (var key in fc.AllKeys)
                {
                    if (key.Contains("txt_1"))
                    {
                        lbl_1 = fc["txt_1"].ToString();
                    }
                }
             }
