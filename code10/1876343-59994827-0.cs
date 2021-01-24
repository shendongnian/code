        cartesianChart1.VisualElements.Add(new VisualElement
        {
            X = 0.5,
            Y = 7,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Top,
            UIElement = new TextBlock //notice this property must be a wpf control
            {
                Text = "Warning!",
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                Opacity = 0.6
            }
        });
