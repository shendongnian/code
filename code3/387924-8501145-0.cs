    IF (  btn.IsEnabled = True )
    {
       Button btn = sender as Button;
       //string buttonContent = btn.Content.ToString();
       MedwaiverTimeLog timeLogObj = btn.DataContext as MedwaiverTimeLog;
       MedwaiverViewModel MedwaiverViewModelObj = new MedwaiverViewModel();
       MedwaiverViewModelObj.ChangeBillingStatus(timeLogObj.ListItemId, "Billed");
       btn.IsEnabled = false;
    }
