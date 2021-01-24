using System.Globalization;
using System.Linq;
using System.Windows.Controls;
public class NameRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        return value is string str && str.All(ch => ch < 128)
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "The name contains illegal characters");
    }
}
The `ch < 128` part is the ASCII check.
You also need to specify that you want to use the rule in your binding (supposing that your rule lives in the `c` XAML namespace).
<TextBox Name="PbnameText" Visibility="Collapsed" IsReadOnly="False">
    <TextBox.Text>
        <Binding Path="Name" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged">
            <Binding.ValidationRules>
                <c:NameRule />
            </Binding.ValidationRules>
        </Binding>
    </TextBox.Text>
</TextBox>
You can find more information on data binding validation [in the docs](https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-binding-validation?view=netframework-4.8).
