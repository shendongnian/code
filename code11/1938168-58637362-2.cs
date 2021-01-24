    using System.Windows.Input;
    using MvvmHelpers.Interfaces;
    
    namespace NameSpace.ViewModel
    {
        public partial class HomeViewModel : BaseViewModel
        {
    
            private ObservableCollection<Bill> _listOfbills = new ObservableCollection<Bill>();
            public ObservableCollection<Bill> ListOfbills
            {
                get => _listOfbills;
                set => SetProperty(ref _listOfbills, value);
            }
            public HomeViewModel()
            {
                DataService ds = new DataService();
                ListOfbills = ds.GetBillsAsync()
            }
        }
    }
