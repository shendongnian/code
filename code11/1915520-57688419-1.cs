    var viewModel = new ViewModel();
    viewModel.PropertyChanged += (s, e) =>
    {
        if (e.PropertyName == nameof(viewModel.Steps))
        {
            drehteller.RenderTransform.BeginAnimation(
                RotateTransform.AngleProperty,
                new DoubleAnimation
                {
                    By = viewModel.Steps * 72,
                    Duration = TimeSpan.FromSeconds(3)
                });
        }
    };
    DataContext = viewModel;
