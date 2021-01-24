    private void ListViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(ListViewItems.SelectedIndex != -1)
        {
            var index = ListViewItems.SelectedIndex;
            Note note = MainWindow.dBConnector.NotesList[index];
            ShowNote(note);
            ListViewItems.SelectedIndex = -1;
        }
    }    
