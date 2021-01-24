    public class QuantityToBackgroundConverterM : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush sb = Brushes.White;
            try
            {
                if (values[0] != DependencyProperty.UnsetValue)
                {
                    int i = System.Convert.ToInt32(values[0]);
                    string column = (string)values[1];
                    switch (column)
                    {
                        case "name":
                            if (i % 2 == 0) { sb = Brushes.LightBlue; }
                            break;
                        case "location":
                            if (i % 3 == 0) { sb = Brushes.Yellow; }
                            break;
                    }
                }
            }
            catch (Exception){}
            return sb;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class MainWindow : Window
    {
        DataConti dataconti = new DataConti();
        void DataGridAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            Binding bid = new Binding();
            bid.Path = new PropertyPath("id");
            Binding bheadername = new Binding();
            bheadername.Source = e.Column.Header as String;
            Binding bcolumn = new Binding();
            bcolumn.Path = new PropertyPath(e.Column.Header as String);
            MultiBinding binder = new MultiBinding();
            binder.Bindings.Add(bid);
            binder.Bindings.Add(bheadername);
            binder.Bindings.Add(bcolumn);
            binder.Converter = new QuantityToBackgroundConverterM();
            Setter setter = new Setter(DataGridRow.BackgroundProperty, binder);
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(setter);
            e.Column.CellStyle = style;
        }
