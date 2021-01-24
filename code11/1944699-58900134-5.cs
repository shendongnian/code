    // Attached Behavior
    public class ListView : DependencyObject
    {
      #region IsColumnTextAlignmentEnabled attached property
      public static readonly DependencyProperty IsColumnTextAlignmentEnabledProperty = DependencyProperty.RegisterAttached(
        "IsColumnTextAlignmentEnabled", typeof(bool), typeof(ListView), new PropertyMetadata(false, ListView.OnIsColumnTextAlignmentEnabledChanged));
      public static void SetIsColumnTextAlignmentEnabled(DependencyObject attachingElement, bool value) => attachingElement.SetValue(ListView.IsColumnTextAlignmentEnabledProperty, value);
      public static bool GetIsColumnTextAlignmentEnabled(DependencyObject attachingElement) => (bool) attachingElement.GetValue(ListView.IsColumnTextAlignmentEnabledProperty);
      #endregion
      #region TextAlignment attached property
      public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.RegisterAttached(
        "TextAlignment", typeof(TextAlignment), typeof(ListView), new PropertyMetadata(TextAlignment.Left, ListView.OnTextAlignmentChanged));
      public static void SetTextAlignment(DependencyObject attachingElement, TextAlignment value) => attachingElement.SetValue(ListView.TextAlignmentProperty, value);
      public static TextAlignment GetTextAlignment(DependencyObject attachingElement) => (TextAlignment) attachingElement.GetValue(ListView.TextAlignmentProperty);
      #endregion
      private static Dictionary<GridViewColumn, System.Windows.Controls.ListView> ColumnListViewTable { get; }
      static ListView()
      {
        ListView.ColumnListViewTable = new Dictionary<GridViewColumn, System.Windows.Controls.ListView>();
      }
      private static void OnTextAlignmentChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
      {
        // Get the parent ListView of the current column
        if (attachingElement is GridViewColumn gridViewColumn 
          && ListView.ColumnListViewTable.TryGetValue(gridViewColumn, out System.Windows.Controls.ListView listView))
        {
          ListView.AlignColumns(listView);
        }
      }
      private static void OnIsColumnTextAlignmentEnabledChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
      {
        if (!(attachingElement is System.Windows.Controls.ListView listView))
        {
          return;
        }
        bool isEnabled = (bool) e.NewValue;
        if (isEnabled)
        {
          if (!listView.IsLoaded)
          {
            listView.Loaded += ListView.InitializeColumnsOnListViewLoaded;
            return;
          }
          ListView.InitializeColumns(listView);
        }
        else
        {
          ListView.UnregisterColumns(listView);
        }
      }
      private static void InitializeColumnsOnListViewLoaded(object sender, RoutedEventArgs e)
      {
        var listView = sender as System.Windows.Controls.ListView;
        listView.Loaded -= ListView.InitializeColumnsOnListViewLoaded;
        ListView.InitializeColumns(listView);
      }
      private static void InitializeColumns(System.Windows.Controls.ListView listView)
      {
        if (ListView.TryRegisterColumns(listView))
        {
          ListView.AlignColumns(listView);
        }
      }
      private static void AlignColumns(System.Windows.Controls.ListView listView)
      {
        IEnumerable<ListBoxItem> listViewItemContainers = listView.Items
          .OfType<object>()
          .Select(item => listView.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem);
        foreach (ListBoxItem listViewItemContainer in listViewItemContainers)
        {
          if (!listViewItemContainer.TryFindVisualChildElement(out GridViewRowPresenter rowPresenter))
          {
            continue;
          }
          List<object> rowElements = LogicalTreeHelper.GetChildren(rowPresenter)
            .Cast<object>()
            .ToList();
          for (int columnIndex = 0; columnIndex < rowPresenter.Columns.Count; columnIndex++)
          {
            if (rowElements.ElementAt(columnIndex) is TextBlock textBlock)
            {
              textBlock.TextAlignment = ListView.GetTextAlignment(rowPresenter.Columns.ElementAt(columnIndex));
            }
            // Because the TextBlock's width is set to Auto
            // the aligned text will always appear to be left aligned.
            // Therefore set equivalent HorizontalAlignment to compensate.
            // Also setting the HorizontalAlignment enables alignment of all FrameworkElements
            if (rowElements.ElementAt(columnIndex) is FrameworkElement frameworkElement)
            {
              frameworkElement.HorizontalAlignment = ListView.GetHorizontalAlignment(textBlock.TextAlignment);
            }
          }
        }
      }
      private static HorizontalAlignment GetHorizontalAlignment(TextAlignment textBlockTextAlignment)
      {
        switch (textBlockTextAlignment)
        {
          case TextAlignment.Center: return HorizontalAlignment.Center;
          case TextAlignment.Right: return HorizontalAlignment.Right;
          case TextAlignment.Justify: return HorizontalAlignment.Stretch;
          default: return HorizontalAlignment.Left;
        }
      }
      private static void UnregisterColumns(System.Windows.Controls.ListView listView)
      {
        if (!(listView.View is System.Windows.Controls.GridView gridView))
        {
          return;
        }
        gridView.Columns
          .ToList()
          .ForEach(column => ListView.ColumnListViewTable.Remove(column));
      }
      private static bool TryRegisterColumns(System.Windows.Controls.ListView listView)
      {
        if (!(listView.View is System.Windows.Controls.GridView gridView))
        {
          return false;
        }
        gridView.Columns
          .ToList()
          .ForEach(column => ListView.ColumnListViewTable.Add(column, listView));
        return true;
      }
    }
