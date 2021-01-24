            Grid boardValidar = tablero.Content as Grid;
            Button[,] botones = new Button[boardValidar.ColumnDefinitions.Count, boardValidar.ColumnDefinitions.Count];
            var buttons = boardValidar.Children.Cast<Button>();
            for (int i = 0; i < boardValidar.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < boardValidar.RowDefinitions.Count; j++)
                {
                    botones[i, j] = buttons.Where(x => Grid.GetRow(x) == j && Grid.GetColumn(x) == i).FirstOrDefault();
                }
            }
