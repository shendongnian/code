    private void ShowOneDataGridViewAndHideOthers(string name)
    {
        foreach (var DGV in this.Controls.OfType<DataGridView>())
        {
            DGV.Visible = DGV.Name == name;
        }
    }
