     async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.Gender = (string)myPicker.SelectedItem;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }
