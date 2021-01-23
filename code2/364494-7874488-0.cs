    private void cboBankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSave.PerformClick();
                e.Handled = true;
            }
        }
