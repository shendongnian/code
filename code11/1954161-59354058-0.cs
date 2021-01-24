    var draggableView = new MR.Gestures.ContentView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Accent
            };
           Content = draggableView;
            draggableView.Panning += (dd, ee) =>
            {
                if (ee.Touches != null)
                {
                    if (ee.Touches.Length == 1)
                    {
                        //draggableView.TranslationX = ee.Touches[0].X;
                        //draggableView.TranslationY = ee.Touches[0].Y;
                        draggableView.TranslationX += ee.DeltaDistance.X;
                        draggableView.TranslationY += ee.DeltaDistance.Y;
                    }
                }
            };
