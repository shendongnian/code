    public JsonResult FindZipCode(string term)
        {
            VetClinicDataContext db = new VetClinicDataContext();
            
            var zipCodes = from c in db.ZipCodes
                           where c.ZipCodeNum.ToString().StartsWith(term)
                           select new { value = c.ZipCodeID, label = c.ZipCodeNum};
            
            return this.Json(zipCodes, JsonRequestBehavior.AllowGet);
        }
