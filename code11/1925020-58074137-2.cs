    Loaded += delegate
    {
        if (DataContext is ListItemVM viewModel)
        {
            viewModel.PropertyChanged += delegate (object o, PropertyChangedArgs args)
            {
                 if (args.PropertyName == nameof(viewModel.ShouldHighlight) && viewModel.ShouldHighlight)
                     // Starts the animation //
            }
        }
    }
