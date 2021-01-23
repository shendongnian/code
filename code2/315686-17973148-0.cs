    public class MyDataGrid : DataGrid
    {
        static MyDataGrid()
        {
            IsEnabledProperty.OverrideMetadata(typeof(MyDataGrid), new CustomFrameworkPropertyMetadata(OnIsEnabledChanged));
        }
        /// <summary>
        /// Fixes the issue that the DataGrid's selection is cleared whenever the DataGrid is disabled.
        /// Tricky: this issue only happens for 4.0 installations, it is fixed in 4.5 (in-place upgrade) installations.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(CanUserAddRowsProperty);
            d.CoerceValue(CanUserDeleteRowsProperty);
            //this is there in 4.0 dlls, not in the in-place upgrade 4.5 dlls.
            //if (!(bool)(e.NewValue))
            //{
            //    ((DataGrid)d).UnselectAllCells();
            //}
            CommandManager.InvalidateRequerySuggested();
        }
        class CustomFrameworkPropertyMetadata : FrameworkPropertyMetadata
        {
            public CustomFrameworkPropertyMetadata(PropertyChangedCallback propertyChangedCallback)
                : base(propertyChangedCallback)
            {
            }
            protected override void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
            {
                // See: http://msdn.microsoft.com/en-us/library/system.windows.propertymetadata.merge.aspx
                // See: http://msdn.microsoft.com/en-us/library/ms751554.aspx
                // By default, PropertyChangedCallbacks are merged from all owners in the inheritance hierarchy,
                // so all callbacks are called whenever the property changes.
                var thisPropertyChangedCallback = this.PropertyChangedCallback;
                base.Merge(baseMetadata, dp);
                // We do NOT want that default behavior here;
                // The callback of DataGrid should not be called here - it clears the selection, we don't want that.
                // But the callback of UIElement should be called here - it visually disabled the element, we still want that.
                if (baseMetadata.PropertyChangedCallback != null)
                {
                    Delegate[] invocationList = baseMetadata.PropertyChangedCallback.GetInvocationList();
                    PropertyChangedCallback inheritedPropertyChangedCallback = null;
                    foreach (var invocation in invocationList)
                    {
                        if (invocation.Method.DeclaringType == typeof(DataGrid))
                        {
                            // Do nothing; don't want the callback from DataGrid that clears the selection.
                        }
                        else
                        {
                            inheritedPropertyChangedCallback = inheritedPropertyChangedCallback == null
                                ? (PropertyChangedCallback)invocation
                                : (PropertyChangedCallback)Delegate.Combine(inheritedPropertyChangedCallback, invocation);
                        }
                    }
                    this.PropertyChangedCallback = thisPropertyChangedCallback != null
                                                       ? (PropertyChangedCallback)Delegate.Combine(inheritedPropertyChangedCallback, thisPropertyChangedCallback)
                                                       : inheritedPropertyChangedCallback;
                }
            }
        }
    }
