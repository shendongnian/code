        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKH.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvKH.SelectedRows[0].Index;
                int PrimaryKey =Convert.ToInt32(dgvKH.Rows[selectedIndex].Cells["ID"].Value);
                /*
                 * Execute this Query HERE. 
                   string sql = "DELETE From MyTable WHERE ID = " + PrimaryKey;
                */
                dgvKH.Rows.RemoveAt(selectedIndex);
            }
            Load();
        }
