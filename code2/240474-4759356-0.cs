    public void Execute(Action action)
    {
        do
        {
            try
            {
                action();
                return;
            }
            catch (Exception exception)
            {
                ErrorMessagesUtils.ShowTaskErrorMessage(exception);
            }
        } while (MessageBox.Show("Failed : Retry ?", "Error",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes);
    }
