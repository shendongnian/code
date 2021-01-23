	AutoCompleteStringCollection allowedStatorTypes = new AutoCompleteStringCollection();
	var allstatortypes = StatorTypeDAL.LoadList<List<StatorType>>().OrderBy(x => x.Name).Select(x => x.Name).Distinct().ToList();
	if (allstatortypes != null && allstatortypes.Count > 0)
	{
		foreach (string item in allstatortypes)
		{
			allowedStatorTypes.Add(item);
		}
	}
	txtStatorTypes.AutoCompleteMode = AutoCompleteMode.Suggest;
	txtStatorTypes.AutoCompleteSource = AutoCompleteSource.CustomSource;
	txtStatorTypes.AutoCompleteCustomSource = allowedStatorTypes;
}
