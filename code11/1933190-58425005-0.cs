     public TestPage1()
     {
           StackLayout stackLayout = new StackLayout{};
            ScrollView scroll = new ScrollView();
            scroll.Content = stackLayout;
            for (int i=0;i<6;i++) {
                var image = new Image
                {
                    Source = "tapped.jpg",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Image_OnTapped;
                image.GestureRecognizers.Add(tapGestureRecognizer);
                stackLayout.Children.Add(image);
            }
            Content = scroll;
     }
