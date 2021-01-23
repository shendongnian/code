    private void EditTopicTextBox_Loaded(object sender, RoutedEventArgs e)
    {
        var textBox = sender as TextBox;
        var editableHelpTopic = textBox.DataContext as EditableHelpTopic;
        if (editableHelpTopic.InEdit)
        {
            textBox.Focus();
            textBox.SelectAll();
        }
    }
