    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox combo = e.Control as ComboBox;
        if (combo != null)
        {
            // Both of these lines are essential, otherwise you will be handling the same event twice in some conditions
            combo.SelectedIndexChanged -= combo_SelectedIndexChanged;
            combo.SelectedIndexChanged += combo_SelectedIndexChanged;
        }
    }
