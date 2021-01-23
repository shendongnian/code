    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            var text = (string)e.DataObject.GetData(typeof(string));
            var composition = new TextComposition(InputManager.Current, this, text);
            TextCompositionManager.StartComposition(composition);
        }
        e.CancelCommand();
    }
