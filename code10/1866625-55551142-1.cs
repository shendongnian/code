        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Geometry geom = this.Resources["Star"] as Geometry;
            Geometry flipped = geom.Clone();
            var bounds = geom.Bounds;
            double halfY = (bounds.Bottom - bounds.Top) / 2.0;
            flipped.Transform = new ScaleTransform(1, -1, 0, halfY );
            PathGeometry pg = PathGeometry.CreateFromGeometry(flipped);
            var path = new System.Windows.Shapes.Path {Data=pg, Fill= System.Windows.Media.Brushes.Red };
            this.myCanvas.Children.Add(path);
        }
