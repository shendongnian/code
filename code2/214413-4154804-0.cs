    void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
        if (e.Control is ComboBox) {
            // remove handler first to avoid attaching twice
            ((ComboBox)e.Control).SelectedIndexChanged -= MyEventHandler;
            ((ComboBox)e.Control).SelectedIndexChanged += MyEventHandler;
        }
    }
