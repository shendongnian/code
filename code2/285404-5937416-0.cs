      DataGridViewImageColumn ic= new DataGridViewImageColumn();
      ic.HeaderText = "Img";
      ic.Image = null;
      ic.Name = "cImg";
      ic.Width = 100;
      DGV.Columns.Add(ic);
      foreach (DataGridViewRow row in DGV.Rows)
      {
        DataGridViewImageCell cell = row.Cells[1] as DataGridViewImageCell;
        cell.Value = (System.Drawing.Image)Properties.Resources.Icon_delete;
      }
