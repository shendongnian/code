        private ICsvParsingService _csvParsingService; // tip: use DI to inject the concrete in ctor.
    
        [HttpGet]
        public ActionResult Csv()
        {
           var csv = _csvParsingService.Parse("http://mydomain.com/test.csv");
           var model = Mapper.Map<SomeCsvType,YourModel>(csv); // AutoMapper. Or you could do L-R.
           return View(model);
        }
