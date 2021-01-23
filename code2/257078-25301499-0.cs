    /// <summary>
    /// Provides a way to set binding between a control
    /// and an object which is not part of the visual tree.
    /// </summary>
    /// <remarks>
    /// A bright example when you need this class is having an 
    /// <see cref="ItemsControl"/> bound to a <see cref="CollectionViewSource"/>.
    /// The tricky thing arises when you want the <see cref="CollectionViewSource.Source"/>
    /// to be bound to some property of the <see cref="ItemsControl"/> 
    /// (e.g. to its data context, and to the view model). Since 
    /// <see cref="CollectionViewSource"/> doesn't belong to the visual/logical tree,
    /// its not able to reference the <see cref="ItemsControl"/>. To stay in markup,
    /// you do the following:
    /// 1) Add an instance of the <see cref="BindingBridge"/> to the resources 
    /// of some parent element;
    /// 2) On the <see cref="ItemsControl"/> set the <see cref="BindingBridge.BridgeInstance"/> attached property to the
    /// instance created on step 1) using <see cref="StaticResourceExtension"/>;
    /// 3) Set the <see cref="CollectionViewSource.Source"/> to a binding which has 
    /// source set (via <see cref="StaticResourceExtension"/>) to <see cref="BindingBridge"/>  
    /// and path set to the <see cref="BindingBridge.SourceElement"/> (which will be the control 
    /// on which you set the attached property on step 2) plus the property of interest
    /// (e.g. <see cref="FrameworkElement.DataContext"/>):
    /// <code>
    ///  <CollectionViewSource
    ///     Source="{Binding SourceElement.DataContext.Images, Source={StaticResource ImagesBindingBridge}}"/>
    /// </code>.
    /// 
    /// So the result is that when assigning the attached property on a control, the assigned 
    /// <see cref="BindingBridge"/> stores the reference to the control. And that reference can be 
    /// retrieved from the <see cref="BindingBridge.SourceElement"/>.
    /// </remarks>
    public sealed class BindingBridge : DependencyObject
    {
        #region BridgeInstance property
        public static BindingBridge GetBridgeInstance(DependencyObject obj)
        {
            Contract.Requires(obj != null);
            return (BindingBridge)obj.GetValue(BridgeInstanceProperty);
        }
        public static void SetBridgeInstance(DependencyObject obj, BindingBridge value)
        {
            Contract.Requires(obj != null);
            obj.SetValue(BridgeInstanceProperty, value);
        }
        // Using a DependencyProperty as the backing store for BridgeInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BridgeInstanceProperty =
            DependencyProperty.RegisterAttached("BridgeInstance", typeof(BindingBridge), typeof(BindingBridge),
            new PropertyMetadata(OnBridgeInstancePropertyChanged));
        #endregion BridgeInstance property
        #region SourceElement property
        public FrameworkElement SourceElement
        {
            get { return (FrameworkElement)GetValue(SourceElementProperty); }
            private set { SetValue(SourceElementPropertyKey, value); }
        }
        // Using a DependencyProperty as the backing store for SourceElement.  This enables animation, styling, binding, etc...
        private static readonly DependencyPropertyKey SourceElementPropertyKey =
            DependencyProperty.RegisterReadOnly("SourceElement", typeof(FrameworkElement), typeof(BindingBridge), new PropertyMetadata(null));
        public static readonly DependencyProperty SourceElementProperty;
        #endregion SourceElement property
        /// <summary>
        /// Initializes the <see cref="BindingBridge"/> class.
        /// </summary>
        static BindingBridge()
        {
            SourceElementProperty = SourceElementPropertyKey.DependencyProperty;
        }
        private static void OnBridgeInstancePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sourceElement = (FrameworkElement)d;
            var bridge = (BindingBridge)e.NewValue;
            bridge.SourceElement = sourceElement;
        }
    }
