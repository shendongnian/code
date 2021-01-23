            imgRect.Width = 240; //Set the width of an individual sprite
            imgRect.Height = 296; //Set the height of an individual sprite
            const int ximages = 6; //The number of sprites in each row
            const int yimages = 5; //The number of sprites in each column
            int currentRow = 0;
            int currentColumn = 0;
    
            TranslateTransform offsetTransform = new TranslateTransform();
            KeyDown += delegate(object sender, KeyEventArgs e)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        currentColumn--;
                        if (currentColumn < 0)
                        {
                            currentColumn = ximages -1;
                            if (currentRow == 0)
                            {
                                currentRow = yimages - 1;
                            }
                            else
                            {
                                currentRow--;
                            }
                        }                        
                        break;
                    case Key.Down:
                        currentColumn++;
                        if (currentColumn == ximages)
                        {
                            currentColumn = 0;
                            if (currentRow == yimages - 1)
                            {
                                currentRow = 0;
                            }
                            else
                            {
                                currentRow++;
                            }
                        }
                        break;
                    default:
                        break;
                }
                offsetTransform.X = -imgRect.Width * currentColumn;
                offsetTransform.Y = -imgRect.Height * currentRow;
                imgBrush.Transform = offsetTransform;
