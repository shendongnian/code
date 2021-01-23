    using System.Windows.Media;
    ...
    static void UpdateBindings(this DependencyObject obj)
    {
        for (var i=0; i<VisualTreeHelper.GetChildrenCount(obj); ++i)
        {
            var child = VisualTreeHelper.GetChild(obj, i);
            if (child is TextBox)
            {
                var expression = (child as TextBox).GetBindingExpression(TextBox.TextProperty);
                if (expression != null)
                {
                    expression.UpdateTarget();
                }
            }
            else if (...) { ... }
            UpdateBindings(child);        
        }
    }
