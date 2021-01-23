    ErrorProvider ep = new ErrorProvider();
    private void txtBox_Validating(object sender, CancelEventArgs e)
    {
        bool bValidated = double.TryParse(txtBox.Text, out txtBoxVar);
        if (bValidated)
        {
            ep.SetError(txtBox, String.Empty);
            ep.Clear();
        }
        else
        {
            ep.SetError(txtBox, "Enter a valid decimal.");
        }
    }
