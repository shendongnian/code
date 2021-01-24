      // GET: SLG/CreateAdmin
        [Authorize(Roles = "WFL_APP_MOCHUB-Admins,WFL_APP_SLG-Admins,Managers,WFL_ROLE_StoreManagmentTeams")]
        public ActionResult CreateAdmin(SLGAdminCreateViewModel value)
        {
            // ViewModel for Both Forms
            var viewModel = new SLGAdminCreateViewModel
            {
                SLGHeader = new SLGHeader(),
                DropDownList = new List<QuarterWeekType>(),
                DropDownListAutoPopulate = new List<string>(),
                TotalBudget = null,
                TotalLaborBudget = null
            };
            // Formating returned value for query to set values.
            if (value.SelectedDropDownValue != null)
            {
                var QuarterYear = value.SelectedDropDownValue.Replace("Q", "").Replace(":", "").Replace(" ", "");
                var Quarter = decimal.Parse(QuarterYear.Substring(0, 1), CultureInfo.InvariantCulture);
                var Year = decimal.Parse(QuarterYear.Substring(1, 4), CultureInfo.InvariantCulture);
                var TotalBudgetList = db.QuarterDetails.Where(x => x.Quarter == Quarter && x.Year == Year && x.Store == 1 && x.Department == "total")
                    .ToList();
                foreach (var x in TotalBudgetList) { viewModel.TotalBudget = x.TotalBudget; viewModel.TotalLaborBudget = x.TotalLaborBudget; };
            }
            // Format dropdown list
            viewModel.DropDownList = db.SLGHeaderTemplates.Where(x => x.Year > 2018 && x.Week == 1).Select(x => new QuarterWeekType { Year = x.Year, Quarter = x.Quarter, QuarterYearConcat = "" }).ToList();
            foreach (var item in viewModel.DropDownList)
            {
                item.QuarterYearConcat = "Q" + Convert.ToInt32(item.Quarter) + " : " + Convert.ToInt32(item.Year);
            }
            foreach (var x in viewModel.DropDownList) { viewModel.DropDownListAutoPopulate.Add(x.QuarterYearConcat); };
    
            return View(viewModel);
        }
