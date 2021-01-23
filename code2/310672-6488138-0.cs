    int[,] n = new int[3, 19];
    
                for (int i = 0; i < (StartDataView.Rows.Count - 1); i++)
                {
                    for (int j = 0; j < StartDataView.Columns.Count; j++)
                    {
                        try
                        {
                            n[i, j] = int.Parse(this.StartDataView.Rows[i].Cells[j].Value.ToString());
                        }
                        catch (Exception Ee)
                        { //get exception of "null"
                            MessageBox.Show(Ee.ToString());
                        }
                    }
                }
