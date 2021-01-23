    void grdPerformanceScenario_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                (e.Control as ComboBox).AutoCompleteMode = AutoCompleteMode.Suggest;
                (e.Control as ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
