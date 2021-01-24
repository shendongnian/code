    DataGridView dat = new DataGridView();
            if (dat.Columns.Count == 0)
            {
                foreach (DataGridViewColumn dgvc in dgvMenuMisDocumentos.Columns)
                {
                    dat.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                }
            }
          
            DataGridViewRow rad = new DataGridViewRow();
            
            var dateAndTime = DateTime.Now;
            var dater = dateAndTime.Date;
            int k = 0;
            foreach (DataGridViewRow rw in dgvMenuMisDocumentos.Rows)
            {
                string state = rw.Cells[dgvMenuMisDocumentos.Columns["fecha_ingreso"].Index].Value.ToString();
               
                if (state == dater.ToString())
                {
                    rad = (DataGridViewRow)dgvMenuMisDocumentos.Rows[k].Clone();
                    int clidx = 0;
                    foreach (DataGridViewCell cell in dgvMenuMisDocumentos.Rows[k].Cells)
                    {
                        rad.Cells[clidx].Value = cell.Value;
                        clidx++;
                    }
                    dat.Rows.Add(rad);
                }
                k++;
            }
            return dat;
