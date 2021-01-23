    foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                checkedListBox1.Items.Add(column.HeaderText, column.Visible);
                checkedListBox1.ItemCheck += (ss, ee) =>
                    {
                        if (checkedListBox1.SelectedItem != null)
                        {
                            var selectedItem = checkedListBox1.SelectedItem.ToString();
                            dataGridView1.Columns[selectedItem].Visible = ee.NewValue == CheckState.Checked; 
                        }
                    };
            }
