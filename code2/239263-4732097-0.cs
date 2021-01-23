    private bool IsChecked(this CheckBox control) {
        return control.IsChecked.HasValue && (bool)control.IsChecked;
    }
    // calls the extension method above.
    myCheckBox.IsChecked()
