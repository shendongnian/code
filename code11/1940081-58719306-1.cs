private bool _closeConfirmed;
private async void MainWindow_OnClosing(object sender, CancelEventArgs e)
{
    //check if flag set
    if(!_closeConfirmed)
    {
        //use flag and always cancel first closing event (in order to allow making OnClosing work as as an async function)
        e.Cancel = true;
        var cancelCloseTask = mainViewModel.ShouldCancelClose();
        //Check if we were given a completed Task, in which case nothing
        //asynchronous happened.
        if (cancelCloseTask.IsCompleted)
        {
            if (!await cancelCloseTask)
            {
                _closeConfirmed = true;
            }
            return;
        }
        if(!await cancelCloseTask)
        {
            _closeConfirmed = true;
            this.Close();
        }
    }
}
