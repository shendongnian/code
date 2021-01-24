    var doubleList = new List<double>(DataGridViewLAS.Rows.Count);
            for (int i = 0; i < DataGridViewLAS.Rows.Count; i++)
            {
                if (DataGridViewLAS.ColumnCount >3 && DataGridViewLAS[3, i].Value != null)
                {
                    doubleList.Add(Convert.ToDouble(DataGridViewLAS[3, i].Value));
                }
            }
