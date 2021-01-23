    foreach (DataGridViewRow row in dgvCalls.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            if (cell.Visible )
            {
                if (cell.Value != null)
                    pdfTable.AddCell(cell.Value.ToString());
                else
                    pdfTable.AddCell("");
            }
            //  continue;
        }
    }
