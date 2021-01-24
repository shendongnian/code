    public ActionResult GetData(Tablet tablet)
        {
            List<Tablet> data = new List<Tablet>();
            data.Add(new Tablet() { Id = 1, Country = "India", Description = "Test", ManufactureDate = DateTime.UtcNow.ToShortDateString() });
            data.Add(new Tablet() { Id = 1, Country = "Canada", Description = "Test1", ManufactureDate = DateTime.UtcNow.ToShortDateString() });
            //string jsonRes = JsonConvert.SerializeObject(data);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
