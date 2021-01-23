        void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            Point cp = PointToClient(new Point(e.X, e.Y)); // Get coordinates of the mouse relative to the datagriedview.
            var dropped = dataGridView1.HitTest(cp.X, cp.Y); // Get the item under the mouse pointer.
            if (dataGridView1.Rows[dropped.RowIndex].Cells[0].Value.ToString() == "not_allowed") // Check the value.
                e.Effect = DragDropEffects.None; // Indicates dragging onto this item is not allowed.
            else
                e.Effect = DragDropEffects.Move; // Set the drag effect as required.
        }
