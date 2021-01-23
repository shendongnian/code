        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            Point pos = dataGridView.PointToClient(Control.MousePosition);
            DataGridView.HitTestInfo hi = dataGridView.HitTest(pos.X, pos.Y);
            if (hi.Type == DataGridViewHitTestType.Cell && hi.RowIndex != e.RowIndex) {
                e.Cancel = !AllowChangeCurrent(); //Check if changing selection is allowed
            }
        }
