        public ActionResult ExtensionData()
        {
            return View();
        }
        public JsonResult get_extensiondata()
        {
            List<ExtensionsData> extensionData = new List<ExtensionsData>();
            //Example of how you could intialize your list
            extensionData.Add(new ExtensionsData
            {
                ExtensionData = { "1", "2" },
                Code = "40",
                Name = "Alex"
            });
            extensionData.Add(new ExtensionsData
            {
                ExtensionData = { "1", "2" },
                Code = "40",
                Name = "Tom"
            });
            extensionData.Add(new ExtensionsData
            {
                ExtensionData = { "1", "2" },
                Code = "10",
                Name = "Bunny"
            });
            var data = extensionData;
            return Json(extensionData, JsonRequestBehavior.AllowGet);
        }
