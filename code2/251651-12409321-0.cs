    private void Number_Validating(object sender, CancelEventArgs e) {
        int val;
        TextBox tb = sender as TextBox;
        if (!int.TryParse(tb.Text, out val)) {
            MessageBox.Show(tb.Tag +  " must be numeric.");
            tb.Undo();
            e.Cancel = true;
        }
    }
