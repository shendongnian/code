    private async Task GetManuallyReadTagsAsyn()
    {
        var model = new ParameterManualTags
        {
            Lane = Convert.ToInt32(TxtLane.Text),
            Plaza = Convert.ToInt32(TxtLane),
            DateTo = DateTo.DisplayDate,
            DateFrom = DateFrom.DisplayDate
        };
         _manualReadTagList = await _ac.GetManuallyReadTags(model);
        ViewingGrid.ItemsSource = _manualReadTagList;
    }
