        [ChildActionOnly]
        public ActionResult GenerateUrlPartial(int id)
        {
            var generatedUrl = "";//your url business is here
            var model = new UrlInfo { Url = generatedUrl };
            //generate your url
            return PartialView(model);
        }
