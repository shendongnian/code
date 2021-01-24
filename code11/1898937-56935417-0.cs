            TextBox[] txtBox = new TextBox[DM.dataGridView1.Columns.Count];
            Label[] labels = new Label[DM.dataGridView1.Columns.Count];
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel() { AutoSize = true };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            int n = 0;
            foreach (DataGridViewColumn column in DM.dataGridView1.Columns)
            {
                labels[column.Index] = new Label();
                labels[column.Index].Text = column.HeaderText;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel.SetCellPosition(labels[column.Index], new TableLayoutPanelCellPosition(0, n++));
                tableLayoutPanel.Controls.Add(labels[column.Index]);
                txtBox[column.Index] = new TextBox();
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel.SetCellPosition(txtBox[column.Index], new TableLayoutPanelCellPosition(0, n++));
                tableLayoutPanel.Controls.Add(txtBox[column.Index]);
            }
            Controls.Add(tableLayoutPanel);
