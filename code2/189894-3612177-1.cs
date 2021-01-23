    public event EventHandler SaveButtonClick = delegate {};
    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        // Replace the original sender with "this"
        SaveButtonClick(this, e);
    }
    ...
    btnSave.Click += OnSaveButtonClicked();
