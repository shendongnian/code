    protected override void OnVisualChildrenChanged(DependencyObject added, DependencyObject removed)
    {
         if (added != null)
         {
            this.children.Add((B) added);
         }
         if (removed != null)
         {
            this.children.Remove((B) removed);
         }
         base.OnVisualChildrenChanged(added, removed);
    }
