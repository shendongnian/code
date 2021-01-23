       try
        {
            frmSetTimer.ShowDialog();
            DateTimeOfNextScheduledDataRun = (DateTime)frmSetTimer.Tag;
            SetDataRunTimer(DateTimeOfNextScheduledDataRun);
            Status = DRMStatus.Scheduled;
        }
        catch (NullReferenceException e)
        {
            Status = DRMStatus.Inactive;
            StatusChanged();
        }
