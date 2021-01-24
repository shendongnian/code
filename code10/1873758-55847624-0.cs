    dataGridView1.KeyDown += (s, ev) =>
    {
        if (ev.KeyCode == Keys.Delete)
        {
            var item = dataGridView1.SelectedRows[0].DataBoundItem as MyViewModel;
            if (item != null)
            {
                _list.Remove(item);
                dataGridView1.Rows[0].Selected = true;
                ev.Handled = true;
            }
        }
    };
    
