    private void gridView1_ShownEditor(object sender, EventArgs e) {
                GridView gridView = sender as GridView;
                if(gridView.FocusedColumn.FieldName == "YourField") {
                    CheckedComboBoxEdit edit = gridView.ActiveEditor as CheckedComboBoxEdit;
                    object value = gridView.GetRowCellValue(gridView.FocusedRowHandle, "AnotherColumn");
                    // filter the datasource and set the editor's DataSource:
                    edit.Properties.DataSource = FilteredDataSource;// your value
                }
            }
