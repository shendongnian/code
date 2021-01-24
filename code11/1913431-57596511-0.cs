C#
public enum ComparisonOperator
{
    Eq, Gt, Gte, Lt, Lte, Neq
}
public class NumericComparisonConverter : MarkupExtension, IMultiValueConverter
{
    public NumericComparisonConverter(ComparisonOperator op)
    {
        _op = op;
    }
    protected ComparisonOperator _op;
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        double value1 = System.Convert.ToDouble(values[0]);
        double value2 = System.Convert.ToDouble(values[1]);
        switch (_op) {
            case ComparisonOperator.Eq: return value1 == value2;
            case ComparisonOperator.Gt: return value1 > value2;
            case ComparisonOperator.Gte: return value1 >= value2;
            
            //  You can fill in the rest
            default:
                throw new ArgumentException($"{_op} isn't a valid numeric comparison operator.");
        }
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
XAML
<DataGrid.Columns>
    <DataGridTextColumn Header="A" Binding="{Binding A}" />
    <DataGridTextColumn Header="B" Binding="{Binding B}">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{local:NumericComparisonConverter Gt}" >
                                <!-- DataContext here is the whole "row" object -->
                                <Binding Path="A" />
                                <Binding Path="B" />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="Background" Value="Yellow" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
    <!-- etc. -->
</DataGrid.Columns>
