    protected override void OnValidating(CancelEventArgs e) {
      if (innerTextBox.Text == string.Empty)
        e.Cancel = true;
      else if (innerComboBox.SelectedIndex == -1)
        e.Cancel = true;
      base.OnValidating(e);
    }
