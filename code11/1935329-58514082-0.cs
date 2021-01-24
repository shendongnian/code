    private async void NewSubjectExisChrtBtn_Clicked(object sender, EventArgs e)
    {
        //_viewModel.LoadChartsCommand.Execute(null); // Returns immediately, so is picker not loaded with items.
        await _viewModel.ExecuteLoadChartsCommand(); // Waits for method to finish before before presenting the picker.
        //NewSubjectExisChrtPck.IsVisible = true;
        NewSubjectExisChrtPck.Focus();
    }
