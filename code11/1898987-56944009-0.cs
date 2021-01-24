    private void button1_Click(object sender, EventArgs e) {
      DataObject o = (DataObject)Clipboard.GetDataObject();
      if (o.GetDataPresent(DataFormats.Text)) {
        dgvAuthG.Columns.Clear();
        string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
        int totCols = pastedRows[0].Split(new char[] { '\t' }).Length;
        for (int i = 0; i < totCols; i++) {
          dgvAuthG.Columns.Add("col" + i, "col" + i);
        }
        string[] pastedRowCells;
        int newRowIndex;
        foreach (string pastedRow in pastedRows) {
          pastedRowCells = pastedRow.Split(new char[] { '\t' });
          newRowIndex = dgvAuthG.Rows.Add();
          for (int i = 0; i < totCols; i++) {
            dgvAuthG.Rows[newRowIndex].Cells[i].Value = pastedRowCells[i];
          }
        }
      }
      //dgvAuthG.Columns.RemoveAt(0);
      //btnFormat.Enabled = true;
      //btnFormatWay4.Enabled = true;
    }
