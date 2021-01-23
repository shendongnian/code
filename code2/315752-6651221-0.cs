    foreach(var subview in scrollViewer.Subviews.Skip(1))
    {
        subview.RemoveFromSuperview();
    }
    
    scrollViewer.AddSubview(newView);
    
    scrollViewer.ContentSize = new System.Drawing.SizeF(newView.Frame.Width, newView.Frame.Height);
