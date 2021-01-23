    if (dgv.IsCurrentCellInEditMode)
    {
                    dgv.EndEdit();
                    updatedData.Rows[dgv.CurrentCell.RowIndex].EndEdit();
    }
                if (updatedData.GetChanges() != null && updatedData.GetChanges().Rows.Count > 0)
    {
         // if there are changes, update the dataset
    }
