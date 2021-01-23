        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
            {
                TextBox cell = new TextBox();
                cell.Top = i * GridHeight;
                cell.Left = j * GridWidth;
                cell.Click += new EventHandler(Cell_Click);
                AllCells.Add(cell);
            }
    And handle the `Cell_Click` event accordingly.
