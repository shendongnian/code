        private void FileCreated_Event(object sender, TrackStatusEventArgs e)
        {
            if ((sender as Control).InvokeRequired)
            {
                (sender as Control).Invoke(action);
            }
            else
            {
                action();
            }
        }
