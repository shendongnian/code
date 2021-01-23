        class MyVM
        {
            FrameworkElement _context;
            public MyVM(FrameworkElement context)
            {
                _context = context;
            }
            public double Width
            {
                get { return _context.ActualWidth; }
            }
        }
