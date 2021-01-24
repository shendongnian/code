        [ChildActionOnly]
        public ActionResult GenerateUrlPartial(int id)
        {
            var generatedUrl = "";//your url business is here
            var model = new UrlInfo { Url = generatedUrl };
            return PartialView(model);
        }
