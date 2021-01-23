    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Interactivity;
    
    namespace MySampleApp
    {
        internal class CancellableSelectionBehavior : Behavior<Selector>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.SelectionChanged += OnSelectionChanged;
            }
    
            protected override void OnDetaching()
            {
                base.OnDetaching();
                AssociatedObject.SelectionChanged -= OnSelectionChanged;
            }
    
            public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register("SelectedItem", typeof(object), typeof(CancellableSelectionBehavior),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));
    
            public object SelectedItem
            {
                get { return GetValue(SelectedItemProperty); }
                set { SetValue(SelectedItemProperty, value); }
            }
    
            /// <summary>
            /// Called when the SelectedItem dependency property is changed.
            /// Updates the associated selector's SelectedItem with the new value.
            /// </summary>
            private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var behavior = (CancellableSelectionBehavior)d;
                var selector = behavior.AssociatedObject;
                selector.SelectedValue = e.NewValue;
            }
    
            /// <summary>
            /// Called when the associated selector's selection is changed.
            /// Tries to assign it to the <see cref="SelectedItem"/> property.
            /// If it fails, updates the selector's with  <see cref="SelectedItem"/> property's current value.
            /// </summary>
            private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                SelectedItem = AssociatedObject.SelectedItem;
                if (SelectedItem != AssociatedObject.SelectedItem)
                {
                    AssociatedObject.SelectedItem = SelectedItem;
                }
            }
        }
    }
