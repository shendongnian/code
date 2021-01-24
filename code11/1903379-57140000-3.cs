            private void Form1_Load(object sender, EventArgs e)
            {
                m_BuildGrid();
            }
    
            private void m_BuildGrid()
            {
                DataGridViewColumn pColumn;
                int i, j;
                String strTemp;
                HMergedCell pCell;
                int nOffset;
    
                dataGridView2.Columns.Add(@"colGroup", @"");
                dataGridView2.Columns.Add(@"colTask", @"Task");
                pColumn = dataGridView2.Columns["colTask"];
                pColumn.Frozen = true;
    
                for (i = 0; i < 25; i++)
                {
                    strTemp = "col" + i.ToString();
                    dataGridView2.Columns.Add(@strTemp, i.ToString());
                    pColumn = dataGridView2.Columns[strTemp];
                    pColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    pColumn.Width = 40;
                }
    
                dataGridView2.Rows.Add(20);
    
                nOffset = 2;
                for (i = 0; i < 3; i++)
                {
                    for (j = nOffset; j < nOffset + 7; j++)
                    {
                        dataGridView2.Rows[0].Cells[j] = new HMergedCell();
                        pCell = (HMergedCell)dataGridView2.Rows[0].Cells[j];
                        pCell.LeftColumn = nOffset;
                        pCell.RightColumn = nOffset + 6;
                    }
                    nOffset += 7;
                }
    
    
                for (i = 0; i < 20; i++)
                    for (j = 0; j < 22; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = "{" + i.ToString() + "," + j.ToString() + "}";
                    }
    
                pColumn = null;
            }
        }
