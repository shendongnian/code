private async void SaveJobNotes(ContentPage sender)
{
    this.InnerPage.PopAsync(); //I don't understand why this works and the 
                                //other didn't, but it correctly pops the page
    if (sender is UpdateJobNotesPage notesPage)
    {
        bool noteSaved = await SaveNewJobNote(notesPage);
        bool progressSaved = await SaveJobProgress(notesPage);
        var message = noteSaved && progressSaved ? 
            "Changes were save successfully" : 
            "An error occurred; changes not saved";
        await DisplayAlert("Save", message, "OK");
    }
}
