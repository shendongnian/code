    void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
        GridView view = sender as GridView;
        if(e.Column.FieldName == "COMM_TYPE" && view.IsFilterRow(e.RowHandle))
            e.RepositoryItem = repositoryItemComboBox1;
    }
