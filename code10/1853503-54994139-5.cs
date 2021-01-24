    [HttpPost]
        public ActionResult ClickDetails(PlaneFormModel formModel)
        {
            // bind model from form also you can use FormCollection instead.
    
            if (!string.IsNullOrEmpty(formModel.DropDownValueSelected))
            {
                ...
            }
            ...
        }
