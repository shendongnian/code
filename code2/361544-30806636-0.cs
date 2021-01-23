    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Interactivity;
    namespace MyApp
    {
        internal class CancellableSelectionBehaviour : Behavior<Selector>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                if (MustPerfomInitialChange)
                {
                    OnSelectedItemChanged(this, InitialChangeEvent);
                    MustPerfomInitialChange = false;
                }
                AssociatedObject.SelectionChanged += OnSelectionChanged;
            }
            protected override void OnDetaching()
            {
                base.OnDetaching();
                AssociatedObject.SelectionChanged -= OnSelectionChanged;
            }
            public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register("SelectedItem", typeof(object), typeof(CancellableSelectionBehaviour),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));
            public object SelectedItem
            {
                get { return GetValue(SelectedItemProperty); }
                set { SetValue(SelectedItemProperty, value); }
            }
            public static readonly DependencyProperty IgnoreNullSelectionProperty =
                DependencyProperty.Register("IgnoreNullSelection", typeof(bool), typeof(CancellableSelectionBehaviour), new PropertyMetadata(true));
            /// <summary>
            /// Determines whether null selection (which usually occurs since the combobox is rebuilt or its list is refreshed) should be ignored.
            /// True by default.
            /// </summary>
            public bool IgnoreNullSelection
            {
                get { return (bool)GetValue(IgnoreNullSelectionProperty); }
                set { SetValue(IgnoreNullSelectionProperty, value); }
            }
            /// <summary>
            /// OnSelectedItemChanged can be raised before AssociatedObject is assigned so we must delay the initial change. 
            /// Using System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke has unwanted side effects.
            /// So we use this bool to know if OnSelectedItemChanged must be called afterwards, in OnAttached
            /// </summary>
            private bool MustPerfomInitialChange { get; set; }
            /// <summary>
            /// OnSelectedItemChanged can be raised before AssociatedObject is assigned so we must delay the initial change. 
            /// Using System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke has unwanted side effects.
            /// So we use this DependencyPropertyChangedEventArgs to save the argument needed to call OnSelectedItemChanged.
            /// </summary>
            private DependencyPropertyChangedEventArgs InitialChangeEvent { get; set; }
            /// <summary>
            /// Called when the SelectedItem dependency property is changed.
            /// Updates the associated selector's SelectedItem with the new value.
            /// </summary>
            private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var behavior = (CancellableSelectionBehaviour)d;
                // OnSelectedItemChanged can be raised before AssociatedObject is assigned so we must delay the initial change.
                if (behavior.AssociatedObject == null)
                {
                    behavior.InitialChangeEvent = e;
                    behavior.MustPerfomInitialChange = true;               
                }
                else
                {
                    var selector = behavior.AssociatedObject;
                    selector.SelectedValue = e.NewValue;               
                }
            }
            /// <summary>
            /// Called when the associated selector's selection is changed.
            /// Tries to assign it to the <see cref="SelectedItem"/> property.
            /// If it fails, updates the selector's with  <see cref="SelectedItem"/> property's current value.
            /// </summary>
            private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (IgnoreNullSelection && (e.AddedItems == null || e.AddedItems.Count == 0)) return;
                SelectedItem = AssociatedObject.SelectedItem;
                if (SelectedItem != AssociatedObject.SelectedItem)
                {
                    AssociatedObject.SelectedItem = SelectedItem;
                }
            }
        }
    }
