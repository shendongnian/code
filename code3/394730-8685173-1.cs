       try
        {
            frmSetTimer.ShowDialog();
            DateTimeOfNextScheduledDataRun = (DateTime)frmSetTimer.Tag;
            SetDataRunTimer(DateTimeOfNextScheduledDataRun);
            Status = DRMStatus.Scheduled;
        }
        catch (NullReferenceException)
        {
            Status = DRMStatus.Inactive;
            StatusChanged();
        }
