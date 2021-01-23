            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() != true)
            { 
                return; 
            }
            Grid grid = new Grid();
            grid.Margin = new Thickness(40);
 
            //do this for each column
            ColumnDefinition coldef;
            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(dialog.PrintableAreaWidth, GridUnitType.Pixel);
            grid.ColumnDefinitions.Add(coldef);
 
            //do this for each row
            RowDefinition rowdef;
            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(1, GridUnitType.Auto);
            grid.RowDefinitions.Add(rowdef);
            //
            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(1, GridUnitType.Auto);
            grid.RowDefinitions.Add(rowdef);
 
            TextBlock myTitle = new TextBlock();
            myTitle.FontSize = 24;
            myTitle.FontFamily = new FontFamily("Arial");
            myTitle.TextAlignment = TextAlignment.Center;
            myTitle.Text = myName;
            grid.Children.Add(myTitle);
            //put it in column 0, row 0
            Grid.SetColumn(myTitle, 0);
            Grid.SetRow(myTitle, 0);
            Image myImage = new Image();
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)this.Width, (int)this.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(myViewPort);
            myImage.Source = bmp;
            myImage.Stretch = Stretch.Uniform;
            grid.Children.Add(myImage);
            //put it in column 0, row 1
            Grid.SetColumn(myImage, 0);
            Grid.SetRow(myImage, 1);
            grid.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
            grid.Arrange(new Rect(new Point(0, 0), grid.DesiredSize));
            dialog.PrintVisual(grid, myName);
