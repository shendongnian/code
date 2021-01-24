c#
private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                string column = dataGridView1.Columns[e.ColumnIndex].Name;
                dataGridView1.Columns[column].Visible = false;
                contextMenuStrip1.Items.Add(column);
            }
        }
private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var menuText = e.ClickedItem.Text;
            dataGridView1.Columns[menuText].Visible = true;
            contextMenuStrip1.Items.Remove(e.ClickedItem);
        }
