            if (viewModel.BeginDate == null)
                viewModel.BeginDate = DateTime.Today.AddMonths(-6);
            if (viewModel.EndDate == null)
                viewModel.EndDate = DateTime.Today;
            if (viewModel.EndDate < viewModel.BeginDate)
                ModelState.AddModelError("", "Invalid Date Range");
            if (string.IsNullOrEmpty(viewModel.Value))
                ModelState.AddModelError("", "No View Selected");
