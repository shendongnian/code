        private bool IsLayoutUpdating;
        private async void MyControlElement_LayoutUpdated(object sender, object e)
        {
            if(DesignMode.DesignModeEnabled)
            {
                if (IsLayoutUpdating) return;
                IsLayoutUpdating = true;
                if (this.IsLoaded) await UpdateControlUI();
                IsLayoutUpdating = false;
            }
        }
