    var finder = new TaxiCompanyFinder();
	finder.FindCompaniesCompleted += (s, args) =>
	{
		if (args.Error == null)
		{
		    TaxiCompanyDisplayList.ItemsSource = args.Results;
		}
		else
		{
			// Do something sensible with args.Error
		}
	}
	finder.FindCompaniesAsync();
