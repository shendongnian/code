    [HttpPost]
        public ActionResult InsertData(int? key)
        {
            var TestData = new Data();
            DataContext.InsertData(TestData);
    
            return Content(TestData.Key.ToString());
        }
