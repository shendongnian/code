    // disable editing  
    private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) {  
        GridView view = sender as GridView;  
        if(view.FocusedColumn.FieldName == "Region" && !USCanada(view, view.FocusedRowHandle))  
            e.Cancel = true;  
    }
