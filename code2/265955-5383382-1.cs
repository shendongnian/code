    private bool CheckExit()
    {
        // checks if the Job is running and if so prompts to continue
        if (_screenCaptureSession.Running())
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Capturing in Progress. Are You Sure You Want To Quit?", "Capturing", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                return false;
            }
        }
        _screenCaptureSession.Stop();
        _screenCaptureSession.Dispose();
        return true;
    }
    private void ExitButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!CheckExit())
        {
            e.Cancel = true;
        }
    }
    private void ExitMenuItemClicked(object sender, EventArgs e)
    {
        CheckExit();
    }
