    internal static List<datatable> SplitTable(DataTable originalTable, int batchSize)
        {
            List<datatable> tables = new List<datatable>();
            DataTable new_table = new DataTable();
            new_table = originalTable.Clone();
            int j = 0;
            int k = 0;
            if (originalTable.Rows.Count &lt;= batchSize)
            {
                new_table.TableName = "Table_" + k;
                new_table = originalTable.Copy();
                tables.Add(new_table.Copy());
            }
            else
            {
                for (int i = 0; i &lt; originalTable.Rows.Count; i++)
                {
                    new_table.NewRow();
                    new_table.ImportRow(originalTable.Rows[i]);
                    if ((i + 1) == originalTable.Rows.Count)
                    {
                        new_table.TableName = "Table_" + k;
                        tables.Add(new_table.Copy());
                        new_table.Rows.Clear();
                        k++;
                    }
                    else if (++j == batchSize)
                    {
                        new_table.TableName = "Table_" + k;
                        tables.Add(new_table.Copy());
                        new_table.Rows.Clear();
                        k++;
                        j = 0;
                    }
                }
            }
            return tables;
        }
