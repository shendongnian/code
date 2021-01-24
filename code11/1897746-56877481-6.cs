	public void bindCountry()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "--Select Country--", Value = "0" });
            cs.Open();
            SqlDataReader dr = (da.SelectCommand = new SqlCommand("SELECT * FROM Country", cs)).ExecuteReader();
            while (dr.Read())
            {
                li.Add(new SelectListItem { Text = dr.GetValue(1).ToString(), Value = dr.GetValue(0).ToString()});
                ViewBag.Country = li;
            }
            cs.Close();
        }  
        public JsonResult getState(int id)
        {
            List<SelectListItem> liStates = new List<SelectListItem>();
            liStates.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            cs.Open();
            SqlDataReader dr = (da.SelectCommand = new SqlCommand("SELECT * FROM State WHERE CountryId = " + id, cs)).ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                liStates.Add(new SelectListItem { Text = dr.GetValue(1).ToString(), Value = dr.GetValue(0).ToString() });
                ViewBag.State = liStates;
                count += 1;
            }
            cs.Close();
            PersonValues.Country = count;
            return Json(new SelectList(liStates, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
