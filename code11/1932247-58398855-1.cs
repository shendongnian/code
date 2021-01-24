    DateTime startDate = DateTime.Parse(textStartDate);
    DateTime endDate = Datetime.Parse(textEndDate);
    IEnumerable<ItenaryModel> itenaryModels = this.SpHelper.getAllListData(clientContext);
    
    return itenaryModels.Where(itenaryModel =>
               startDate <= DateTime.Parse(itenaryModel.StartDate.Date) &&
               DateTime.Parse(itenaryModel.EndDate.Date) <= endDate);
