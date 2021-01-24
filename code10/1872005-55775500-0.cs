C#
    public sealed partial class MainPage : Page
    {
        private List<TableData> Data;
        public MainPage()
        {
            this.InitializeComponent();
            Data = new List<TableData>();
            dataGrid.ItemsSource = Data;
        }
        private void calculate_click(object sender, RoutedEventArgs e)
        {
            int years = Convert.ToInt32(yearInput.Text) - 1;
            for (int i = 1; i <= years; ++i)
            {
                double pow = Math.Pow(1.09, years);
                double basic = Math.Round(Convert.ToDouble(basicInput.Text) * pow),
                    fbp = Math.Round(basic * Convert.ToDouble(fbpInput.Text) / 100),
                    pf = Math.Round(basic * Convert.ToDouble(pfInput.Text) / 100),
                    grat = Math.Round(basic * Convert.ToDouble(gratInput.Text) / 100);
                double inh = Math.Floor(basic + fbp), ars = Math.Round(fbp + basic + pf + grat);
                double rent = Math.Round(Convert.ToDouble(rentInput.Text) * 12),
                    food = Math.Round(Convert.ToDouble(foodInput.Text) * pow),
                    investments = Math.Round(Convert.ToDouble(investmentsInput.Text) * pow),
                    ins = 100000;
                Double cur = inh - rent - food - investments - ins;
                Data.Add(new TableData(basic, fbp, inh, ars, cur));
            }
        }
    }
  [1]: https://docs.microsoft.com/en-us/windows/uwp/data-binding/data-binding-quickstart#binding-to-a-collection-of-items
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8
