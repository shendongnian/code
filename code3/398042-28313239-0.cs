        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            String hdrNum =  String.Format("{0}", e.RowIndex + 1);
            if (dgvResults.Rows[e.RowIndex].HeaderCell.Value == null || hdrNum != dgvResults.Rows[e.RowIndex].HeaderCell.Value.ToString())
            {
                dgvResults.Rows[e.RowIndex].HeaderCell.Value = hdrNum;
            }
        }
