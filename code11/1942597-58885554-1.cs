    [HttpGet]
        public async Task<IActionResult> Details(int? pageNumber, UserMovementsViewModel userMovementsViewModel)
        {
            userMovementsViewModel.StartDateFilter = DateTime.ParseExact(userMovementsViewModel.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			userMovementsViewModel.EndDateFilter = DateTime.ParseExact(userMovementsViewModel.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).SetEndOfDay();
			
			var userMovements = await GetUserMovements(pageNumber, userMovementsViewModel).ConfigureAwait(true);
			ViewBag.StartDateFilter = userMovementsViewModel.StartDateFilter.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
			ViewBag.EndDateFilter = userMovementsViewModel.EndDateFilter.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
			ViewBag.Query = userMovementsViewModel.Query;
			return View(userMovements);
        }
