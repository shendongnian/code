    public class yourViewModel : INotifyPropertyChanged
    
        public DataTable SelectedFeatureDataTable
            {
                get
                {
                    return _selectedFeaturesDataTable;
                }
                set
                {
                   SetProperty(ref _selectedFeaturesDataTable, value, () => SelectedFeatureDataTable);
                   RaisePropertyChanged();
                }
            }
