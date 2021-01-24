    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    namespace WpfTest.ViewModel
    {
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Country> countries;
        private ListCollectionView _countryView;
        public ListCollectionView CountryView
        {
            get { return _countryView; }
            set { this.Set(ref _countryView, value); }
        }
        private Country _SelectedCountry;
        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set { this.Set(ref _SelectedCountry, value); }
        }
        private bool _All;
        public bool All
        {
            get { return _All; }
            set
            {
                this.Set(ref _All, value);
                CountryView.Refresh();
            }
        }
        private bool _Africa;
        public bool Africa
        {
            get { return _Africa; }
            set
            {
                this.Set(ref _Africa, value);
                if (SelectedCountry != null && SelectedCountry.Continent != Continent.Africa)
                {
                    SelectedCountry = null;
                }
                CountryView.Refresh();
            }
        }
        private bool _America;
        public bool America
        {
            get { return _America; }
            set
            {
                this.Set(ref _America, value);
                if (SelectedCountry != null && SelectedCountry.Continent != Continent.America)
                {
                    SelectedCountry = null;
                }
                CountryView.Refresh();
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            countries = new ObservableCollection<Country>(
            new[]
            {
                new Country() { Continent = Continent.Africa, DisplayName = "Algeria" },
                new Country() { Continent = Continent.Africa, DisplayName = "Egypt" },
                new Country() { Continent = Continent.Africa, DisplayName = "Chad" },
                new Country() { Continent = Continent.Africa, DisplayName = "Ghana" },
                new Country() { Continent = Continent.America, DisplayName = "Canada" },
                new Country() { Continent = Continent.America, DisplayName = "Greenland" },
                new Country() { Continent = Continent.America, DisplayName = "Haiti" }
            });
            CountryView = (ListCollectionView)CollectionViewSource.GetDefaultView(countries);
            CountryView.Filter += CountryFilter;
            CountryView.Refresh();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        private bool CountryFilter(object obj)
        {
            if (obj is Country c)
            {
                if (Africa && c.Continent != Continent.Africa)
                {
                    return false;
                }
                if (America && c.Continent != Continent.America)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public enum Continent
    {
        All,
        Africa,
        America
    }
    public class Country
    {
        public string DisplayName { get; set; }
        public Continent Continent { get; set; }
    }
    }
