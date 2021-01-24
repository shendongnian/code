            List<DependencyObject> hitResultsList = new List<DependencyObject>();
        private void RegisterControlOnClick(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition((UIElement)sender);
            VisualTreeHelper.HitTest(this, new HitTestFilterCallback(MyHitTestFilter), new HitTestResultCallback(MyHitTestResult), new PointHitTestParameters(pt));
            
        }
        public HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            return HitTestResultBehavior.Continue;
        }
        public HitTestFilterBehavior MyHitTestFilter(DependencyObject o)
        {
            if (o.GetType().IsSubclassOf(typeof(ContentControl)))
            {
                hitResultsList.Add(o);
                ((Control)o).Background = Brushes.Red;
            }
            return HitTestFilterBehavior.Continue;
        }
