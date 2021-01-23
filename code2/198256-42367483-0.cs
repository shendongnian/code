       Sample code to swap the two rows of a DataGridView 
       private void lblMoveDown_Click(object sender, EventArgs e)
        {
           moveDown();
        }
        private void lblMoveUp_Click(object sender, EventArgs e)
        {
           moveUp();
        }
      private void moveUp()
        {
            if (dgvTemplateListToManage.RowCount > 0)
            {
                if (dgvTemplateListToManage.SelectedRows.Count > 0)
                {                  
                    DataTable dt=dgvTemplateListToManage.DataSource as DataTable;
                    int rowIndex = dgvTemplateListToManage.SelectedRows[0].Index;
                    if (rowIndex != 0)
                    {
                        DataRow row = dt.Rows[rowIndex];
                        DataRow drToDown= dt.Rows[rowIndex-1];
                        DataTable dtTemp = dt.Copy();
                                            
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i != 0)
                            {
                                dtTemp.Rows[rowIndex][i] = drToDown[i].ToString();
                            }
                        }
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i != 0)
                            {
                                dtTemp.Rows[rowIndex-1][i] = row[i].ToString();
                            }
                        }
                        dgvTemplateListToManage.DataSource = dtTemp;
                    }
                 
                }
            }
        }
        
        private void moveDown()
        {           
            DataTable dt = dgvTemplateListToManage.DataSource as DataTable;
            int rowIndex = dgvTemplateListToManage.SelectedRows[0].Index;
            int lastRowIndex = dgvTemplateListToManage.Rows.Count - 1;
            if (lastRowIndex != rowIndex)
            {
              
                DataRow row = dt.Rows[rowIndex];
                DataRow drToUp = dt.Rows[rowIndex + 1];
                DataTable dtTemp = dt.Copy();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != 0)
                    {
                        dtTemp.Rows[rowIndex][i] = drToUp[i].ToString();
                    }
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != 0)
                    {
                        dtTemp.Rows[rowIndex + 1][i] = row[i].ToString();
                    }
                }
                dgvTemplateListToManage.DataSource = dtTemp;
            }
        
        }
