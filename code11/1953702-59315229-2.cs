     public partial class MainPage : ContentPage
    {
        public List<TaxClass> taxs { get; set; }
        public MainPage()
        {
            InitializeComponent();
            taxs = new List<TaxClass>()
            {
                new TaxClass(){amount=12.01,date=DateTime.Parse("2019-01-01")},
                 new TaxClass(){amount=13.01,date=DateTime.Parse("2019-01-01")},
                  new TaxClass(){amount=14.01,date=DateTime.Parse("2019-01-01")},
                   new TaxClass(){amount=15.01,date=DateTime.Parse("2019-01-01")},
                    new TaxClass(){amount=16.01,date=DateTime.Parse("2019-01-01")}
            };
            this.BindingContext = this;
        }
    }
    public class TaxClass
    {
        public double amount { get; set; }
        public DateTime date { get; set; }
    }
