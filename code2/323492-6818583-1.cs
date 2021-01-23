    for (int i = 0; i < _RoomX.Count; i++)
            {
                _RoomX[i] = (Convert.ToDouble(_RoomX[i]) * 20).ToString();
                _RoomY[i] = (Convert.ToDouble(_RoomY[i]) * 20).ToString();
    
                var rectangle = new Rectangle()
                {
    
                    Stroke = Brushes.Black,
                    Fill = brush,
                    Width = Convert.ToDouble(_RoomX[i]),
                    Height = Convert.ToDouble(_RoomY[i]),
                    Margin = new Thickness(
                        left: 15,
                        top: 50,
                        right: 0,
                        bottom: 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
    
                };
    
                Grid grid = new Grid();
                grid.Children.Add(rectangle);
                TextBlock textblock = new TextBlock();
                textblock.Text = "Text to add";
                grid.Children.Add(textblock);
    
                mainCanvas.Children.Add(grid);
            }
    
     
