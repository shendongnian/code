    <ListBox IsSynchronizedWithCurrentItem="True" Visibility="{Binding MachinesPanelVisibility}" 
             ItemsSource="{Binding MachineRulesListView}" 
             SelectedIndex="{Binding ItemSelectionIndex}" />   
    <TextBox HorizontalAlignment="Right" Width="162" 
             Text="{Binding FilterText}" 
             TextWrapping="Wrap" Margin="0,44,18,13" />
-
    public class BusinessRulesWizardViewModel : INotifyPropertyChanged
    {
    
         public ObservableCollection<string> MachineRulesList
         {
           get { return _machineRulesList; }
           set
              {
                _machineRulesList = value;
                 OnPropertyChanged("MachineRulesList");
              }
         }
    
         public string FilterText
         {
           get { return _filterText; }
           set
              {
                _filterText= value;
                 OnPropertyChanged("FilterText");
                MachineRulesListView.Refresh();
              }
         }
    
         public ICollectionView MachineRulesListView { get; private set; }
    
    
    
        public BusinessRulesWizardViewModel(ISystemView systemViewManager, IEventAggregator eventAggregator)
        {
             _machineRulesList = new ObservableCollection<string>();
            MachineRulesListView = CollectionViewSource.GetDefaultView(_machineRulesList);
            MachineRulesListView.Filter = new Predicate<object>(r => ((string)r).Contains(FilterText));
    
            _systemViewManager.GetMachines(page, pageSize).ToList().ForEach(
                item => _machineRulesList.Add(item)
             );
        }
    }
