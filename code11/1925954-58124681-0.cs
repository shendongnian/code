        public object Clusters
        {
            get { return (object)GetValue(ClustersProperty); }
            set { SetValue(ClustersProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClustersProperty =
            DependencyProperty.Register("Clusters", typeof(object), typeof(NavigatorControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    private void DrawClusters(ref DrawingContext dc, ref double SquareWidth, ref double SquareHeight)
        {
            if (Clusters == null)
                return;
            if (ClustersVisibility == Visibility.Visible)
            {
                ICollectionView cv = (ICollectionView)Clusters;
                foreach (ClusterBase cluster in cv)
                {
                    PathGeometry geometry = new PathGeometry();
                    foreach (ClusterSquare square in cluster.Squares)
                    {
                        geometry = Geometry.Combine(geometry, new RectangleGeometry(square.ToRect(SquareWidth, SquareHeight)), GeometryCombineMode.Union, null);
                    }
                    dc.DrawGeometry(clustersbrush, clusterspen, geometry);
                }
            }
        }
