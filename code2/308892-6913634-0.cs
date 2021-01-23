        void dc_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult Res = MessageBox.Show("Do you want to save?", "Save document?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (Res)
            {
                case MessageBoxResult.Cancel:
                    //User cancelled, he probably doesn't want to close the window
                    e.Cancel = true; 
                    break;
                case MessageBoxResult.No:
                    //Nothing to do - continue closing
                    e.Cancel = false;
                    break;
                case MessageBoxResult.Yes:
                    //He does want to save - launch save here!
                    Save_Function_For_DocumentContent(sender);
                    e.Cancel = false;
                    break;
                default:
                    //Something unexpected, better abort
                    e.Cancel = true; 
                    break;
            }
