    void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var viewModel = this.BindingContext as ViewModel;
        if(viewModel == null)
            return;
        if(string.IsNullOrEmpty(e.NewTextValue))
        {
            viewModel.ObjectViewModel.MyStringIsValid = true;
            return;
        }
        viewModel.ObjectViewModel.MyStringIsValid = false;
    }
