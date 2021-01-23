            private void _dgvDb_CellFormatting(Object sender, DataGridViewCellFormattingEventArgs e){
            if (e.Value != null && !String.IsNullOrEmpty(e.Value.ToString()))
            {
                switch (_dgvDb.Columns[e.ColumnIndex].Name)
                {
                    case "YOUR_COLUMNNAME":
                        if("value==yourChosenValue"){
                        }
                    break;
                    case "else":
                    }
             }
      }
