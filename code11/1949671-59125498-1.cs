private void Btn_selectall_Click(object sender, EventArgs e)
{
    if (dataGridView1.Rows.Cast<DataGridViewRow>().All(r => r.Selected))
    {
        // deselect all
        foreach (DataGridViewRow item in dataGridView1.Rows)
        {
            item.Selected = false;
            item.Cells[0].Value = false;
        }
    }
    else
    {
        // select all
        foreach (DataGridViewRow item in dataGridView1.Rows)
        {
            item.Selected = true;
            item.Cells[0].Value = true;
        }
    }
}
