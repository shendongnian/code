    MessageBoxResult res = MessageBox.Show(Constants.MSG_LOCKED_BODY, Constants.MSG_LOCKED_TITLE, MessageBoxButton.OKCancel);
            
            if (res == MessageBoxResult.OK) {
                PhoneApplicationService.Current.ApplicationIdleDetectionMode = IdleDetectionMode.Disabled;
            }
