    public DataGridViewRow this[int index]
    {
      get
      {
        DataGridViewRow dataGridViewRow = this.SharedRow(index);
        if (dataGridViewRow.Index != -1)
        {
          return dataGridViewRow;
        }
        if ((index == 0) && (this.items.Count == 1))
        {
          dataGridViewRow.IndexInternal = 0;
          dataGridViewRow.StateInternal = this.SharedRowState(0);
          if (this.DataGridView != null)
          {
            this.DataGridView.OnRowUnshared(dataGridViewRow);
          }
          return dataGridViewRow;
        }
        DataGridViewRow row2 = (DataGridViewRow) dataGridViewRow.Clone();
        row2.IndexInternal = index;
        row2.DataGridViewInternal = dataGridViewRow.DataGridView;
        row2.StateInternal = this.SharedRowState(index);
        this.SharedList[index] = row2;
        int num = 0;
        foreach (DataGridViewCell cell in row2.Cells)
        {
          cell.DataGridViewInternal = dataGridViewRow.DataGridView;
          cell.OwningRowInternal = row2;
          cell.OwningColumnInternal = this.DataGridView.Columns[num];
          num++;
        }
        if (row2.HasHeaderCell)
        {
          row2.HeaderCell.DataGridViewInternal = dataGridViewRow.DataGridView;
          row2.HeaderCell.OwningRowInternal = row2;
        }
        if (this.DataGridView != null)
        {
          this.DataGridView.OnRowUnshared(row2);
        }
        return row2;
      }
    }
