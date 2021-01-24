    TransformedTimeDatas = TimeDatas.Select(timeData =>
    {
        EmployeeAndWorkTime[] viewModels = new EmployeeAndWorkTime[timeData.WorkTimes.Count];
        for (int i = 0; i < timeData.WorkTimes.Count; ++i)
            viewModels[i] = new EmployeeAndWorkTime()
            {
                Name = string.Format("{0} {1}", timeData.Employee.FirstName, timeData.Employee.LastName),
                Date = timeData.WorkTimes[i].Date,
                Hours = timeData.WorkTimes[i].Hours,
                TimeCode = timeData.WorkTimes[i].TimeCode
            };
        return viewModels;
    }).ToArray();
    ListCollectionView collectionView = new ListCollectionView(TransformedTimeDatas);
    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
    this.grdTimeData.ItemsSource = collectionView;
