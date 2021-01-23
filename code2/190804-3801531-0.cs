    try
    {
        Deployment.Current.Dispatcher.BeginInvoke(() => throw new Exception("Sucks to be you."));
    }
    catch(System.Exception ex)
    {
         ErrorMessageBox.Show(ex.Message);
    }
