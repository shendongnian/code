            DataGridCell tempCell = new DataGridCell();
            Style cellStyle = new Style();
            cellStyle.TargetType = tempCell.GetType();
            cellStyle.Setters.Add(new Setter(DataGridCell.ForegroundProperty, new SolidColorBrush(Colors.Red)));
            gridAllContacts.Columns[0].CellStyle = cellStyle;
             
