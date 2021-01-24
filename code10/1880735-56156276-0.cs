            if (this.dataReporte.Columns[e.ColumnIndex].Name == "accepted")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    dataReporte.CurrentRow.CellStyle.BackColor = Color.GreenYellow;
                }
                else
                {
                    dataReporte.CurrentRow.CellStyle.BackColor = Color.Red;
                }
          
