    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    
    namespace WpfApp1
    {
        public class MainWindowViewModel : INotifyPropertyChanged
        {
            public MainWindowViewModel()
            {
                var data = Model.GetData();
                Safeties.AddRange(data);
                Years.AddRange(data.Select(d => d.Year).Distinct());
                Quarters.AddRange(data.Select(d => d.Quarter).Distinct());
                Names.AddRange(data.Select(d => d.Name).Distinct());
            }
    
            private ObservableCollection<int> years = new ObservableCollection<int>();
            public ObservableCollection<int> Years
            {
                get { return years; }
            }
    
            private int _years_SelectedValue;
            public int years_SelectedValue
            {
                get { return _years_SelectedValue; }
                set
                {
                    _years_SelectedValue = value;
                    OnPropertyChanged("years_SelectedValue");
                }
            }
    
            private ObservableCollection<int> quarters = new ObservableCollection<int>();
            public ObservableCollection<int> Quarters
            {
                get { return quarters; }
            }
    
            private int _quarters_SelectedValue;
            public int quarters_SelectedValue
            {
                get { return _quarters_SelectedValue; }
                set
                {
                    _quarters_SelectedValue = value;
                    OnPropertyChanged("quarters_SelectedValue");
                }
            }
    
            private ObservableCollection<string> names = new ObservableCollection<string>();
            public ObservableCollection<string> Names
            {
                get { return names; }
            }
    
            private string _names_SelectedValue;
            public string names_SelectedValue
            {
                get { return _names_SelectedValue; }
                set
                {
                    _names_SelectedValue = value;
                    OnPropertyChanged("names_SelectedValue");
                }
            }
    
            private ObservableCollection<Safety> safeties = new ObservableCollection<Safety>();
            public ObservableCollection<Safety> Safeties
            {
                get { return safeties; }
            }
    
            private Safety selectedSafety;
            public Safety SelectedSafety
            {
                get { return selectedSafety; }
                set
                {
                    selectedSafety = value;
                    this.OnPropertyChanged(nameof(SelectedSafety));
                    if (this.selectedSafety != null)
                    {
                        this.years_SelectedValue = selectedSafety.Year;
                        this.quarters_SelectedValue = selectedSafety.Quarter;
                        this.names_SelectedValue = selectedSafety.Name;
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
