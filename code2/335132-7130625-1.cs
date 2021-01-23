    for (int i = 0; i < dgvData.Items.Count; i++)
    {
        DataGridRow row = GetRow(dgvData, i);
        if (row != null && Validation.GetHasError(row))
        {
            hasDataGridErrors = true;
            break;
        }
    }
