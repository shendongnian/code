    private void CheckButton_Click(object sender, RoutedEventArgs e)
    {
        // Get instance of my LINQ to SQL datacontext
        var db = new MyDbDataContext();
        // Try to get the record that matches the text in the InputTextBox
        var data = db.TableName.FirstOrDefault(r => r.Id == InputTextBox.Text);
        // Was able to find a matching record so show results data
        if (data != null)
        {
            ResultsTextBox.Text = data.EventDesc;
        }
        else 
        {
            // do what ever you need to do when there is no match
        }
    }
