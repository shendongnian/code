           DependencyObject obj = this.DocumentScrollViewer;
            do
            {
                 if (VisualTreeHelper.GetChildrenCount(obj) > 0)
                 {
                    obj = VisualTreeHelper.GetChild(obj as Visual, 0);
                 }
            }
            while (!(obj is ScrollViewer));
            this.scroller = obj as ScrollViewer;
