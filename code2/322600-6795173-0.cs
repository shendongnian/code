    private void workerUpdateBuildHistory_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        UpdateStatusModel model = (UpdateStatusModel)e.Argument;
        BuildService buildService = new BuildService(model.TFSUrl);
        e.Result = buildService.UpdateBuildHistoryList(model);
    }
    private void workerUpdateBuildHistory_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        BuildHistoryListModel model = (BuildHistoryListModel)e.Result;
        if (model != null)
        {
            listViewPastBuilds.Items.Clear();
            foreach (var item in model.Builds)
            {
                listViewPastBuilds.Items.Add(item);
            }
        }
    }
