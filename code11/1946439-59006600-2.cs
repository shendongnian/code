    public void AutomaticMoveUpdateAnchorPoint()
            {
                double x = Canvas.GetLeft(MyBorder);
                double y = Canvas.GetTop(MyBorder);
                switch (Name)
                {
                    case "ThTop":
                        x += (MyBorder.BorderContent.ActualWidth * 0.5d) + (MyBorder.RootGrid.ColumnDefinitions[0].ActualWidth * 1.75d);
                        y += (MyBorder.RootGrid.RowDefinitions[0].ActualHeight * 0.5d);
                        break;
                    case "ThBottom":
                        x += (MyBorder.BorderContent.ActualWidth * 0.5d) + (MyBorder.RootGrid.ColumnDefinitions[0].ActualWidth * 1.75d);
                        y += MyBorder.BorderContent.ActualHeight + (MyBorder.RootGrid.RowDefinitions[0].ActualHeight * 1.5d);
                        break;
                    case "ThLeft":
                        x += (MyBorder.RootGrid.ColumnDefinitions[0].ActualWidth);
                        y += (MyBorder.BorderContent.ActualHeight * 0.5d) + (MyBorder.RootGrid.RowDefinitions[0].ActualHeight);
                        break;
                    case "ThRight":
                        x += (MyBorder.RootGrid.ColumnDefinitions[1].ActualWidth) + (MyBorder.RootGrid.ColumnDefinitions[0].ActualWidth * 2.25d);
                        y += (MyBorder.BorderContent.ActualHeight * 0.5d) + (MyBorder.RootGrid.RowDefinitions[0].ActualHeight);
                        break;
                }
                AnchorPoint = new Point(x, y);
            }
