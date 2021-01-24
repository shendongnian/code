    ContentView LoadingView = new ContentView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Red
            };
            ProgressBar progressBar = new ProgressBar
            {
                ProgressColor = Color.FromHex("#3897F0"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30
            };
            RelativeLoadingLayout.Children.Add(LoadingView,
                    Constraint.RelativeToParent((parent) =>
                    {
                        return (0);
                    }),
                    Constraint.RelativeToParent((parent) =>
                    {
                        return (0);
                    }),
                    Constraint.RelativeToParent((parent) =>
                    {
                        return parent.Width;
                    }), Constraint.RelativeToParent((parent) =>
                    {
                        return parent.Height;
                    }));
    LoadingView.Content = progressBar;        
