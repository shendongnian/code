        private void JournalSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e?.SelectedItem == null) return;
            JournalGroupList.SelectedItem = null;
            JournalHistoryViewPage journalHistoryViewPage = App.Container.Resolve<JournalHistoryViewPage>();
            journalHistoryViewPage.BaseViewModel.JournalGroup = e.SelectedItem as JournalGroup;
            journalHistoryViewPage.BaseViewModel.SelectedPatient = BaseViewModel.SelectedPatient;
            Navigate(journalHistoryViewPage);
        }
        private async void VitalSigns_Tapped(object sender, System.EventArgs e)
        {
            var vitalSignsViewPage = App.Container.Resolve<VitalSignsViewPage>();
            vitalSignsViewPage.BaseViewModel.SelectedPatient = BaseViewModel.SelectedPatient;
            Navigate(vitalSignsViewPage);
        }
        public override async void Navigate(Page  page)
        {        
            await Navigation.PushAsync(page, true);
        }
       
