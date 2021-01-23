        void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow)); // Get the row that is being dragged.
            if (row.Cells[0].Value.ToString() == "no_drag") // Check the value of the row.
                e.Effect = DragDropEffects.None; // Prevent the drag.
            else
                e.Effect = DragDropEffects.Move; // Allow the drag.
        }
