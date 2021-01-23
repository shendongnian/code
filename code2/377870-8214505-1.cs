    /* !DISCLAIMER! The following code may occasionally cause the desired cell
       to flicker or briefly display its text as selected */
    
    // The previously selected cell is stored
    DataGridViewCell previousCurrentCell = dataGridView1.CurrentCell;
    // The desired cell is set as current, needed to get it in edit mode
    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[colIndex];
    // Both the Grid and the Cell need to be editable
    dataGridView1.ReadOnly = false;
    dataGridView1.CurrentCell.ReadOnly = false;
    if (dataGridView1.BeginEdit(false))
    {
        // .. do here whatever you need to, eg:
        Console.WriteLine(
             // Control inside the currentCell
             dataGridView1.EditingControl.ToString()); 
    
        // Restore pre
        dataGridView1.CancelEdit();
        dataGridView1.CurrentCell.ReadOnly = true;
        dataGridView1.ReadOnly = true;
        // dataGridView1.CurrentCell = null if you don't want any selected cell
        dataGridView1.CurrentCell = previousCurrentCell;
    }
