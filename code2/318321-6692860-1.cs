    private void BindSweepList()
    {            
        _sweepCollection = _dataAccess.TopSweeps();
        _dataAccess.CollectionChanged<CableSweepDebug>(new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Local_CollectionChanged));
        UpdateSweepsData();
    }
    private void Local_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
         UpdateSweepsData();
    }
    private void UpdateSweepsData()
    {
        if (comboBoxSweepIds.InvokeRequired)
        {
            Invoke(new UpdateSweepCount(UpdateSweepsData));
        }
        else
        {
            var tmpBind = _sweepCollection.OrderByDescending(t => t.BaseSweepId).Take(100);
                                
            comboBoxSweepIds.DataSource = null;
            comboBoxSweepIds.DataSource = tmpBind.ToList() ;
            comboBoxSweepIds.DisplayMember = "BaseSweepId";
            comboBoxSweepIds.ValueMember = "BaseSweepId";                
            
        }
    }
