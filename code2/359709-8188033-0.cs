    protected void ValidateMatrix(object sender, System.ComponentModel.CancelEventArgs e)
    {
        // perform validation logic
        if (validationFailed)
        {
            e.Cancel = true;
        }
    }
