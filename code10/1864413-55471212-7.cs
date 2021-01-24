    private void Button_OnClicked(object sender, EventArgs e)
    {
        var cell = listView.TemplatedItems.FirstOrDefault();
        var entry = (Entry)cell.FindByName("cellEntry");
        DisplayAlert("My Entry", entry.Text, "Close");
    }
