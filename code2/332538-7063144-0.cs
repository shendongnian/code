     DataTable dtblFinal = new DataTable();
        foreach (DataTable table in dataset.Tables)
        {
            dtblFinal.Merge(table, false, MissingSchemaAction.Add);
        }
