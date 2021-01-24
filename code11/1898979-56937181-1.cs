    private async Task SearchMethod()
    {
        CurrentProgressControl.Visibility = Visibility.Visible;
        CurrentProgressControl.BringIntoView();
        var tempJob = new Job(SearchBox.Text, CurrentProgressControl);
        if (tempJob.MasterJob != null)
        {
            CurrentProgressControl.progressBar.Value = 25;
            CurrentProgressControl.label.Content = "Getting SubJobs";
            await tempJob.GetSubJobsAsync();
            CurrentProgressControl.Update("Getting Planning Lines and Ledger Entries.", 45);
            await tempJob.GetPlanningLinesandLedgerEntriesAsync();
            CurrentProgressControl.Update("Creating the Estimate Line List.", 60);
            await tempJob.CreateEstimateLineListAsync();
            CurrentProgressControl.Update("Separating into Labor and Material.", 75);
            await tempJob.SeparateTableLinesAsync(tempJob.TableLines);
            CurrentProgressControl.Update("Creating SubTotals.", 85);
 
            await tempJob.ob.CreateSubtotalLinesAsync(tempJob.LaborLines);
            await tempJob.CreateSubtotalLinesAsync(tempJob.MaterialLines);
            CurrentProgressControl.Update("Calculating Totals.", 95);
            await tempJob.CalculateTableAsync(tempJob.MaterialLines);
            await tempJob.CalculateTableAsync(tempJob.LaborLines);
            await tempJob.CalculateTotalsAsync();
            CurrentProgressControl.Update("Completed Successfully.", 100);
            _masterJob = tempJob;
            RaisePropertyChanged("MasterJob");
        }
    }
