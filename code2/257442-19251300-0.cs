      private void dgvRequete_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
          if (dgvRequete.SelectedRows.Count > 0)
              idRequetePourtriage = Convert.ToInt32(dgvRequete.SelectedRows[0].Cells[TEXT_colNameIdRequete].Value.ToString());
      }
      private void dgvRequete_Sorted(object sender, EventArgs e)
      {
          desactivateGridSelected();
          int rowCount = 0;
          Boolean isFind = false;
          while (rowCount < dgvRequete.Rows.Count && !isFind)
          {
              if (idRequetePourtriage == Convert.ToInt32(dgvRequete.Rows[rowCount].Cells[TEXT_colNameIdRequete].Value.ToString()))
              {
                  isFind = true;
                  activateGridSelected();
                  dgvRequete.Rows[rowCount].Selected = true;
              }
              rowCount++;
          }
          if (!isFind)
          {
              activateGridSelected();
          }
      }
