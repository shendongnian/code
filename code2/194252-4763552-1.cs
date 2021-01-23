        /// </summary>
        protected override void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue, bool sendToServer)
        {
            if (sendToServer)
                SendPropertyChangeToServer(propertyName, newValue);
            // Check if we are on the UI thread or not
            if (App.Current.RootVisual == null || App.Current.RootVisual.CheckAccess())
            {
                // broadcast == false because I don't know why it would ever be true
                base.RaisePropertyChanged(propertyName, oldValue, newValue, false);
            }
            else
            {
                // Invoke on the UI thread
                // Update bindings 
                // broadcast == false because I don't know why it would ever be true
                GalaSoft.MvvmLight.Threading.DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    base.RaisePropertyChanged(propertyName, oldValue, newValue, false));
            }
        }
