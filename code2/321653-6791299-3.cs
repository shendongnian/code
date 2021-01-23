    public class IncentiveLineHelperObjectSort : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                System.Collections.ObjectModel.ObservableCollection<StaffIncentiveLineHelperObject> collection = value as System.Collections.ObjectModel.ObservableCollection<StaffIncentiveLineHelperObject>;
                ListCollectionView view = new ListCollectionView(collection);
                System.ComponentModel.SortDescription sort = new System.ComponentModel.SortDescription(parameter.ToString(), System.ComponentModel.ListSortDirection.Ascending);
                view.SortDescriptions.Add(sort);
    
                return view;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
