     public JsonResult GetStates()
        {
            var model = new List<StateObject>();
            if (!string.IsNullOrEmpty(id))
            {
                var schedule = _settingsService.GetStates().ToList();
                return Json(new SelectList(schedule, "StateCode", "Name"), new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
            else
                return Json(new SelectList(model, "StateCode", "Name"), new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
