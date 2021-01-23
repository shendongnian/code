    using System.Windows.Data;
    using System.ComponentModel;
    ICollectionView view = CollectionViewSource.GetDefaultView(resultsGrid.ItemsSource);
                                 if (view != null && view.SortDescriptions.Count>0)
                                 {
                                     view.SortDescriptions.Clear();
                                     foreach (DataGridColumn column in resultsGrid.Columns)
                                     {
                                         column.SortDirection = null;
                                     };
                                 }
