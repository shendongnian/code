    private async void AddMasterJob_Click(object sender, RoutedEventArgs e)
    {
        await SearchMethod();
    }
    private async Task SearchMethod()
    {
        CurrentProgressControl.Visibility = Visibility.Visible;
        CurrentProgressControl.BringIntoView();
        var tempJob = new Job(SearchBox.Text, CurrentProgressControl);
        if (tempJob.MasterJob != null)
        {
            CurrentProgressControl.progressBar.Value = 25;
            CurrentProgressControl.label.Content = "Getting SubJobs";
            await Task.Run(() => tempJob.GetSubJobs());
            CurrentProgressControl.Update("Getting Planning Lines and Ledger Entries.", 45);
            await Task.Run(() => tempJob.GetPlanningLinesandLedgerEntries());
            CurrentProgressControl.Update("Creating the Estimate Line List.", 60);
            await Task.Run(() => tempJob.CreateEstimateLineList());
            CurrentProgressControl.Update("Separating into Labor and Material.", 75);
            await Task.Run(() => tempJob.SeparateTableLines(tempJob.TableLines));
            CurrentProgressControl.Update("Creating SubTotals.", 85);
 
            await Task.Run(() =>
            {
                tempJob.CreateSubtotalLines(tempJob.LaborLines);
                tempJob.CreateSubtotalLines(tempJob.MaterialLines);
            });
            CurrentProgressControl.Update("Calculating Totals.", 95);
            await Task.Run(() =>
            {
                tempJob.CalculateTable(tempJob.MaterialLines);
                tempJob.CalculateTable(tempJob.LaborLines);
                tempJob.CalculateTotals();
            });
            CurrentProgressControl.Update("Completed Successfully.", 100);
            _masterJob = tempJob;
            RaisePropertyChanged("MasterJob");
        }
    }
