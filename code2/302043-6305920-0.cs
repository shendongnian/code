    protected override void ListViewItem_MouseDoubleClick(MouseButtonEventArgs e) {
        var originalSource = e.OriginalSource as System.Windows.Media.Visual;
        if (originalSource.IsDescendantOf(this)) {
            // Test for IsDescendantOf because other event handlers can have changed
            // the visual tree such that the actually clicked original source
            // component is no longer in the tree.
            // You may want to handle the "not" case differently, but for my
            // application's UI, this makes sense.
            for (System.Windows.DependencyObject depObj = originalSource;
                 depObj != this;
                 depObj = System.Windows.Media.VisualTreeHelper.GetParent(depObj))
            {
                if (depObj is System.Windows.Controls.Primitives.ButtonBase) return;
            }
        }
        MessageBox.Show("ListViewItem doubleclicked.");
    }
