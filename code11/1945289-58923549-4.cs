    public class NewExpenseViewModel
    {
        private readonly IDataService DataService;
        public ExpenseType ExpenseType { get; set; }
        CollectionViewSource VatRatesSource { get; set; }
        public ICollectionView VatRatesView => VatRatesSource.View;
        private NewExpenseViewModel(ServiceProvider serviceProvider, ExpenseType expenseType, VatRate vatRate)
        {
            DataService = serviceProvider.GetService<IDataService>();
            ExpenseType = expenseType;
            VatRatesSource = new CollectionViewSource() { Source = DataService.GetVatRates() };
            VatRate = vatRate;
        }
        public static NewExpenseViewModel Create(ServiceProvider sp, ExpenseType expenseType, VatRate vat)
        {
            DataService = serviceProvider.GetService<IDataService>();
            ExpenseType = expenseType;
            VatRatesSource = new CollectionViewSource() { Source = DataService.GetVatRates() };
            VatRate = vatRate;
        }
        public static NewExpenseViewModel Create(ServiceProvider sp, ExpenseType expenseType)
        {
            var instance = Create(sp, expenseType, 0);
            instance.Vat = 
                ((IEnumerable<VatRate>)VatRatesSource.Source).FirstOrDefault(v => v.VatRateID.Equals(ExpenseType.SuggestedVatRateID));
            return instance;
        }
    }
