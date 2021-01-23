    public void MovementHandler(object sender, ScatterManipulationDeltaEventArgs e)
            {
                updateConnectingLines(sender);
            }
    
            public void ScatterSizeChanged(object sender, SizeChangedEventArgs e)
            {
                updateConnectingLines(sender);
            }
    
            private void updateConnectingLines(object sender)
            {
                removeOldLines((sender as ScatterViewItem).Tag as String);
    
                Point childPosition = (sender as ScatterViewItem).TransformToAncestor(_surfaceWindow.ClassScatter).Transform(new Point(0, 0));
                Point parentPosition = _surfaceWindow.RootContainer.TransformToAncestor(_surfaceWindow).Transform(new Point(0, 0));
    
                Line line = new Line();
                line.X1 = parentPosition.X;
                line.Y1 = parentPosition.Y;
                line.X2 = childPosition.X;
                line.Y2 = childPosition.Y;
                line.Stroke = System.Windows.Media.Brushes.Black;
                line.StrokeThickness = 2;
                line.Tag = this.name;
                lines.Add(line);
    
                _surfaceWindow.RootGrid.Children.Add(line);
            }
