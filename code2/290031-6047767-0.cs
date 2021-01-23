    [HttpPost]
        public ActionResult ResultSummary(ResultSummaryViewModel resultSummaryViewModel)
        {
            if (!ModelState.IsValid)
                return View("ResultSummary", resultSummaryViewModel);
            return RedirectToAction("ResultSummary",
                                    new
                                        {
                                            beginDate = resultSummaryViewModel.BeginDate,
                                            endDate = resultSummaryViewModel.EndDate,
                                            value = resultSummaryViewModel.Value
                                        });
        }
