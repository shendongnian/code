    private void gridView1_FilterEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e) {
        DevExpress.XtraEditors.Repository.RepositoryItemComboBox combo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
        combo.Items.Add("Item 1");
        combo.Items.Add("Item 2");
        e.FilterControl.FilterColumns["ProductName"].SetColumnEditor(combo);
    }
