    private void orderReceipt_ReportError(object sender, ReportErrorEventArgs e)
    {
        MetroFramework.MetroMessageBox.Show(this, e.Exception.ToString(), "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        e.Handled = true;
    }
