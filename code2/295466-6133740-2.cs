                List<int> list = new List<int>();
                foreach (DataGridViewCell cell in dg.SelectedCells)
                {
                    list.Add(cell.OwningRow.Index);
                    list.Sort();
                }
                int i = int.Parse(list[dg.SelectedCells.Count - 1].ToString());
