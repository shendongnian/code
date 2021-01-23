    [HttpGet]
        public JsonResult GetCityList(Int32 StateID)
        {
            List<tblCityMaster> _lstCitys = GetCitybyID(StateID);
            List<SelectListItem> _liCity = new List<SelectListItem>();
            _liCity.Add(new SelectListItem { Text = "[Select One]", Value = "[Select One]" });
            foreach (var _item in _lstCitys)
            {
                _liCity.Add(new SelectListItem { Text = _item.CityName, Value = _item.CityIDPK.ToString() });
            }
            return Json(new SelectList(_liCity, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
