        public static readonly DependencyProperty RefreshViewProperty =
            DependencyProperty.Register("RefreshView", typeof(bool), typeof(MyView), new PropertyMetadata(false, OnRefreshViewChanged));
        private static void OnRefreshViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyView mv = (MyView)d;
            mv.DoStuff();
            ((MyViewModel)mv.DataContext).RefreshFromViewModel = false;
        }
