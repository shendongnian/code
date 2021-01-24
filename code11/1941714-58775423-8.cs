        public void CreateShotGridDefaultValues ()
        {
            for (int y = 0; y < shotGrid.GetLength(1); y++)
            {
                for (int x = 0; x < shotGrid.GetLength(0); x++)
                {
                    shotGrid[x, y] = '~';
                }
            }
        }
