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
    
        cartesianChart1.VisualElements.Add(new VisualElement()
        {
                X=0,
                Y=myCalculatedValue,
                UIElement = new Rectangle()
                {
                    Width= width,
                    Margin= new Thickness(-seriesWidth/2, 0, 0, 0),
                    Height=6,
                    Fill=Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Top
                }
        });
