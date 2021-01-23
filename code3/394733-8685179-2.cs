    frmSetTimer.ShowDialog();
    if (frmSetTimer.Tag == null) {
       Status = DRMStatus.Inactive;
       StatusChanged();
    }
    else {
       SetDataRunTimer((DateTime)frmSetTimer.Tag);
       Status = DRMStatus.Scheduled;
    }
