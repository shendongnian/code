     public ActionResult Ajouter()
            {
                db = new IdentityDBEntities2();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
    
                foreach (var item in db.Categories.ToList())
                {
                    selectListItems.Add(new SelectListItem() { Value = item.Id, Text = item.libelle });
                }
                ViewBag.categ = selectListItems;
    
                return View();
            }
    
    
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            [Route("Create")]
    
            public ActionResult Ajouter([Bind(Include = "Ida,description,image,Userid,Idc,titre")] Article article, HttpPostedFileBase postedFile)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (postedFile != null)
                        {
                            db = new IdentityDBEntities2();
                            article.image = Convert.ToString(postedFile.ContentLength);
                            postedFile.InputStream.Read(System.Text.Encoding.Unicode.GetBytes(article.image), 0, postedFile.ContentLength);
                            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
                            string FilePath = "~/Content/img/" + fileName;
                            postedFile.SaveAs(Server.MapPath(FilePath));
                            article.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                            article.Idc = Convert.ToInt32(Request["Cab"]);
                            article.image = fileName;
                            db.Articles.Add(article);
    
                            List<SelectListItem> selectListItems = new List<SelectListItem>();
    
                            foreach (var item in db.Categories.ToList())
                            {
                                selectListItems.Add(new SelectListItem() { Value = item.Id, Text = item.libelle });
                            }
                            ViewBag.categ = selectListItems;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    else return View(article);
    
    
                }
                catch
                {
                    return View();
                }
                return View();
            }
