        public ActionResult Index()
        {
            int value;
            if (int.TryParse(Request.Params["amount"], out value))
            {
                ViewData["formmessage"] = calculatepressed(value);
            }
            return View();
        }
        private string calculatepressed(int value)
        {
            // Do your magic here and return the value you calculate
            return value.ToString();
        }
