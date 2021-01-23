        internal static BindingExpression CreateBindingExpression(DependencyObject d, DependencyProperty dp, Binding binding, BindingExpressionBase parent)
        {
            FrameworkPropertyMetadata fwMetaData = dp.GetMetadata(d.DependencyObjectType) as FrameworkPropertyMetadata;
            if (((fwMetaData != null) && !fwMetaData.IsDataBindingAllowed) || dp.ReadOnly)
            {
                throw new ArgumentException(System.Windows.SR.Get(System.Windows.SRID.PropertyNotBindable, new object[] { dp.Name }), "dp");
            }
            ....
