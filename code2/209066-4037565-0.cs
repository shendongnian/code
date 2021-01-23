        public ActionResult QuadCalcIndex()
        {
            return View();
        }
		public ActionResult QuadCalcResult(QuadCalc quadCalc)
		{
			double x1;
			double x2;
			quadCalc.QuadCalculate(out x1, out x2);
			ViewData["x1"] = x1;
			ViewData["x2"] = x2;
			return View();
		}
