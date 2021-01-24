    IEnumerable<ItenaryModel> FilterDashboard(string textStartDate, string textEndDate, ...)
    {
        // TODO: check for non-null textStartDate, textEndDate
        // convert the input dates to DateTime:
        DateTime startDate = DateTime.Parse(textStartDate);
        DateTime endDate = Datetime.Parse(textEndDate);
        // TODO: decide what to do if dates can't be parsed
        // TODO: decide what to do if startDate > endDate?
        IEnumerable<ItenaryModel> itenaryModels = this.SpHelper.getAllListData(clientContext);
        // the easiest is a foreach, alternatively use a LINQ where.
        foreach (var itenaryModel in itenaryModels)
        {
            DateTime itenaryStartDate = DateTime.Parse(itenaryModel.StartDate.Date);
            DateTime itenaryEndDate = DateTime.Parse(itenaryMode.EndDate.Date);
            // TODO: decide what to do if can't be parsed
            if (startDate <= itenaryStartDate && itenaryEndDate <= endDate)
            {
                 // put this itenaryModel in the returned enumeration
                 yield return itenaryModel;
            }
        }
    }
