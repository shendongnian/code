     private void OnProgress(object sender, EventArgs args)
        {
            Dispatcher.Invoke(DispatcherPriority.Send, (Action)delegate() { TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None; });
            // Use here your progress type
        }
