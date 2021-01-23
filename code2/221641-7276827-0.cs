        public void DisableGridviewSorting(DataGridView grid, int index)
        {
            //Index = DataGridView.Columns.Count
            for (int i = 0; i < index; i++)
            {
                grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
