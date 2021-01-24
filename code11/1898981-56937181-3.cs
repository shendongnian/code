    private async Task SearchMethod()
    {
        CurrentProgressControl.Visibility = Visibility.Visible;
        CurrentProgressControl.BringIntoView();
        var tempJob = new Job(SearchBox.Text, CurrentProgressControl);
        if (tempJob.MasterJob != null)
        {
            CurrentProgressControl.progressBar.Value = 25;
            CurrentProgressControl.label.Content = "Getting SubJobs";
            await Task.Run(() =>
            {
                tempJob.GetSubJobs());
                Dispatcher.Invoke(() => CurrentProgressControl.Update("Getting Planning Lines and Ledger Entries.", 45));
                tempJob.GetPlanningLinesandLedgerEntries();
                Dispatcher.Invoke(() => CurrentProgressControl.Update("Creating the Estimate Line List.", 60));
                tempJob.CreateEstimateLineList();
                Dispatcher.Invoke(() => CurrentProgressControl.Update("Separating into Labor and Material.", 75));
                tempJob.SeparateTableLines(tempJob.TableLines);
                Dispatcher.Invoke(() => CurrentProgressControl.Update("Creating SubTotals.", 85));
 
                tempJob.CreateSubtotalLines(tempJob.LaborLines);
                tempJob.CreateSubtotalLines(tempJob.MaterialLines);
                Dispatcher.Invoke(() => CurrentProgressControl.Update("Calculating Totals.", 95));
                tempJob.CalculateTable(tempJob.MaterialLines);
                tempJob.CalculateTable(tempJob.LaborLines);
                tempJob.CalculateTotals();
            });
            CurrentProgressControl.Update("Completed Successfully.", 100);
            _masterJob = tempJob;
            RaisePropertyChanged("MasterJob");
        }
    }
