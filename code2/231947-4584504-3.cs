    private static void handleException(
        Exception exception)
    {
        LogCentral.Current.LogError(
            @"Exception occurred.",
            exception);
    
        if (ErrorForm.IsErrorFormShowing)
        {
            LogCentral.Current.LogInfo(
                @"Error form already showing, not showing again.",
                exception);
        }
        else
        {
            using (var form = new ErrorForm(exception))
            {
                var result = form.ShowDialog();
    
                if (result == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
        }
    }
