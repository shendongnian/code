     public TestPage1()
     {
           StackLayout stackLayout = new StackLayout{};
            ScrollView scroll = new ScrollView();
            scroll.Content = stackLayout;
            foreach (Categories c in categorie) {
                var image = new Image
                {
                    Source = ImageSource.FromUri(new Uri(c.imageUrl))
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
