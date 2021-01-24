    IEnumerable<string> GetAllCombinationOfFirstNColumns(DataGridView dataGrid, int column0BasedIndex)
    {
        if(column0BasedIndex==0)
        {
            for (int row = 1; row < dataGrid.Rows.Count && dataGrid.Rows[row].Cells[column0BasedIndex].Value != null; row++)
            {
                yield return dataGrid.Rows[row].Cells[column0BasedIndex].Value.ToString();
            }
        }
        else
        {
            foreach(string previousCombination in GetAllCombinationOfFirstNColumns(dataGrid, column0BasedIndex-1))
            {
                for (int row = 1; row < dataGrid.Rows.Count && dataGrid.Rows[row].Cells[column0BasedIndex].Value != null; row++)
                {
                    yield return previousCombination + "+" + dataGrid.Rows[row].Cells[column0BasedIndex].Value.ToString();
                }
            }
        }
    }
