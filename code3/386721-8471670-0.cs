    [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string[] Descriptions = collection.GetValues("item.Description");
           for (int i = 1; i <= Descriptions.Length; i++)
            {
                MyModel element = db.MyModels.Find(i);
                element.Description = Descriptions[i - 1];
                db.Entry(element).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(db.MyModels.ToList());
        }
