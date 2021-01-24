    void Handle_TextChanged(object sender, TextChangedEventArgs args)
    {
         var viewModel = BindingContext as MainViewModel;
         viewModel.LabelTextPress = args.NewTextValue;
    }
