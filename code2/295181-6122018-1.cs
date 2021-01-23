    public static class DatagridService
    {
        #region SelectedItemSource
        #region Attached Property Declaration
        /// <summary>
        /// Identifies the ListBoxExtension.SelectedItemsSource attached property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsSourceProperty =
           DependencyProperty.RegisterAttached(
              "SelectedItemsSource",
              typeof(IList),
              typeof(DatagridService),
              new PropertyMetadata(
                  null,
                  new PropertyChangedCallback(OnSelectedItemsSourceChanged)));
        #endregion
        #region Attached Property Accessors
        /// <summary>
        /// Gets the IList that contains the values that should be selected.
        /// </summary>
        /// <param name="element">The ListBox to check.</param>
        public static IList GetSelectedItemsSource(DependencyObject element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            return (IList)element.GetValue(SelectedItemsSourceProperty);
        }
        /// <summary>
        /// Sets the IList that contains the values that should be selected.
        /// </summary>
        /// <param name="element">The ListBox being set.</param>
        /// <param name="value">The value of the property.</param>
        public static void SetSelectedItemsSource(DependencyObject element, IList value)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.SetValue(SelectedItemsSourceProperty, value);
        }
        #endregion
        #region IsResynchingProperty
        // Used to set a flag on the ListBox to avoid reentry of SelectionChanged due to
        // a full syncronisation pass
        private static readonly DependencyPropertyKey IsResynchingPropertyKey =
           DependencyProperty.RegisterAttachedReadOnly(
                "IsResynching",
                typeof(bool),
                typeof(DatagridService),
                new PropertyMetadata(false));
        #endregion
        #region Private Static Methods
        private static void OnSelectedItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGrid grd = d as DataGrid;
            if (grd == null)
                throw new InvalidOperationException("The DataGridExtension.SelectedItemsSource attached " +
                   "property can only be applied to DataGrid controls.");
            grd.SelectionChanged -= new SelectionChangedEventHandler(OnDataGridSelectionChanged);
            if (e.NewValue != null)
            {
                ListenForChanges(grd);
            }
            BindingExpression bexp = grd.GetBindingExpression(SelectedItemsSourceProperty);
            if (bexp != null)
                bexp.UpdateSource();
        }
        private static void ListenForChanges(DataGrid grd)
        {
            // Wait until the element is initialised
            if (!grd.IsInitialized)
            {
                EventHandler callback = null;
                callback = delegate
                {
                    grd.Initialized -= callback;
                    ListenForChanges(grd);
                };
                grd.Initialized += callback;
                return;
            }
            grd.SelectionChanged += new SelectionChangedEventHandler(OnDataGridSelectionChanged);
            ResynchList(grd);
        }
        private static void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grd = sender as DataGrid;
            if (grd != null)
            {
                bool isResynching = (bool)grd.GetValue(IsResynchingPropertyKey.DependencyProperty);
                if (isResynching)
                    return;
                IList list = GetSelectedItemsSource(grd);
                if (list != null)
                {
                    foreach (object obj in e.RemovedItems)
                    {
                        if (list.Contains(obj))
                            list.Remove(obj);
                    }
                    foreach (object obj in e.AddedItems)
                    {
                        if (!list.Contains(obj))
                            list.Add(obj);
                    }
                }
            }
        }
        private static void ResynchList(DataGrid grd)
        {
            if (grd != null)
            {
                grd.SetValue(IsResynchingPropertyKey, true);
                IList list = GetSelectedItemsSource(grd);
                if (grd.SelectionMode == DataGridSelectionMode.Single)
                {
                    grd.SelectedItem = null;
                    if (list != null)
                    {
                        if (list.Count > 1)
                        {
                            // There is more than one item selected, but the listbox is in Single selection mode
                            throw new InvalidOperationException("DataGrid is in Single selection mode, but was given more than one selected value.");
                        }
                        if (list.Count == 1)
                            grd.SelectedItem = list[0];
                    }
                }
                else
                {
                    grd.SelectedItems.Clear();
                    if (list != null)
                    {
                        foreach (object obj in grd.Items)
                            if (list.Contains(obj))
                                grd.SelectedItems.Add(obj);
                    }
                }
                grd.SetValue(IsResynchingPropertyKey, false);
            }
        }
        #endregion
        #endregion
    }
