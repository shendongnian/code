        async void OnEditPlayerButtonClicked(object send, EventArgs e)
        {
            await floatingButtonEdit.ScaleTo(1.5, 500);
            await floatingButtonEdit.ScaleTo(0, 500, Easing.SpringOut);
            await Navigation.PushAsync(new RosterEntryPage(ViewModel));
        }
