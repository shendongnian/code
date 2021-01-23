                ArrayList array = new ArrayList();
                foreach (DataGridViewCell cell in dg.SelectedCells)
                {
                    array.Add(cell.OwningRow.Index);
                    array.Sort();
                }
                int i = int.Parse(array[dg.SelectedCells.Count - 1].ToString());
