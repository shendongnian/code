    [HttpGet]
        public ActionResult ResultSummary(DateTime? beginDate = null, DateTime? endDate = null, string value="")
        {
            var resultSummaryViewModel = new ResultSummaryViewModel();
            resultSummaryViewModel.BeginDate = beginDate;
            resultSummaryViewModel.EndDate = endDate;
            resultSummaryViewModel.Value = value;
