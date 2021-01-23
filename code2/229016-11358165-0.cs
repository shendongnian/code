    DataGridViewCell blockCell = null;
    if (dataGridView.Columns.Contains(columnNameBlock))
    {
        blockCell = dataGridView[columnNameBlock, e.RowIndex];
    }
    if (blockCell != null)
    {
        if (blockCell.Value == null)
        {
            e.CellStyle.BackColor = Color.Red;
        }
        else
        {
            Block blockOfCurrentRow = (Block)blockCell.Value;
            Block blockOfRowBefore = null;
            // Wont hit at first Row!
            if (e.RowIndex > 0)
            {
                blockOfRowBefore = (Block)dataGridView[columnNameBlock, e.RowIndex - 1].Value;
            }
            if (blockOfRowBefore != null)
            {
                //Trace.WriteLine("------------------------------------------------------");
                //Trace.WriteLine(String.Format("RowIndex: {0}", e.RowIndex));
                //Trace.WriteLine(String.Format("ColumnIndex: {0}", e.ColumnIndex));
                //Trace.WriteLine(String.Format("Current Block: {0}", blockOfCurrentRow.BlockNummer));
                //Trace.WriteLine(String.Format("Prev Block: {0}", blockOfRowBefore.BlockNummer));
                if (blockOfCurrentRow == blockOfRowBefore)
                {
                    e.CellStyle.BackColor = m_BlockColors[blockOfCurrentRow];
                }
                else
                {
                    // Previous Row was gray:
                    if (m_BlockColors[blockOfRowBefore] == Color.LightGray)
                    {
                        if (!m_BlockColors.ContainsKey(blockOfCurrentRow))
                        {
                            m_BlockColors.Add(blockOfCurrentRow, Color.White);
                        }
                    }
                    // Previous Row was white:
                    else
                    {
                        if (!m_BlockColors.ContainsKey(blockOfCurrentRow))
                        {
                            m_BlockColors.Add(blockOfCurrentRow, Color.LightGray);
                        }
                    }
                    e.CellStyle.BackColor = m_BlockColors[blockOfCurrentRow];
                }
            }
            else
            {
                // first Row
                if (!m_BlockColors.ContainsKey(blockOfCurrentRow))
                {
                    m_BlockColors.Add(blockOfCurrentRow, Color.White);
                }
                e.CellStyle.BackColor = m_BlockColors[blockOfCurrentRow];
            }
        }
    }
