    private void ShowDialogAndDoSomethingBasedOnTheResult()
    {
        DialogResult result = MessageBox.Show(
            "Dialog text",
            "Caption to go in title bar",
            MessageBoxButtons.OK);
        if (result == DialogResult.OK)
        {
            //Do work
        }
    }
