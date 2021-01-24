    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding DataContext.ShowSelectedCat, RelativeSource={RelativeSource AncestorType=DataGrid}}" Value="True" />
            <Condition Value="True">
                <Condition.Binding>
                    <MultiBinding>
                        <MultiBinding.Converter>
                            <local:MultiConverter />
                        </MultiBinding.Converter>
                        <Binding Path="DataContext.SelectedCat" RelativeSource="{RelativeSource AncestorType=DataGrid}" />
                        <Binding Path="Cat" />
                    </MultiBinding>
                </Condition.Binding>
            </Condition>
        </MultiDataTrigger.Conditions>
        <Setter ... />
    </MultiDataTrigger>
----------
    public class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) =>
            values[0]?.Equals(values[1]);
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
