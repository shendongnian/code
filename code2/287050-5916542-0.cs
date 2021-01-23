    if (docRelComboBox.SelectedValue == null ||
          string.IsNullOrEmpty(docRelComboBox.SelectedValue.ToString()))
    {
       document = "other";
    }
    else
    {
       document = docRelComboBox.SelectedValue.ToString();
    }
