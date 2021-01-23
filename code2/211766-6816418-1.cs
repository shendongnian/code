                public static readonly DependencyProperty NotifySourceUpdatesProperty
                = DependencyProperty.RegisterAttached(
                  "NotifySourceUpdates",
                  typeof(bool),
                  typeof(MyAttachedBehavior),
                  new FrameworkPropertyMetadata(false, OnNotifySourceUpdates)
                );
                public static void SetNotifySourceUpdates(UIElement element, bool value)
                {
                    element.SetValue(NotifySourceUpdatesProperty, value);
                }
                
                public static Boolean GetNotifySourceUpdates(UIElement element)
                {
                    return (bool)element.GetValue(NotifySourceUpdatesProperty);
                }
                private static void OnNotifySourceUpdates(DependencyObject d, DependencyPropertyEventArgs e)
                {
                    if ((bool)e.NewValue)
                    {
                        ((DataGridCell)d).AddHandler(Binding.SourceUpdated, OnSourceUpdatedHandler);
                    }
                }
