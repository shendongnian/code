    <TextBox>
        <Binding Path="Text" UpdateSourceTrigger="PropertyChanged">
            <Binding.ValidationRules>
                <WpfApplication1:MyValidationRule />
            </Binding.ValidationRules>
        </Binding>
    </TextBox>
    <Button>
         <Button.IsEnabled>
             <Binding ElementName="TB" Path="(Validation.HasError)">
                 <Binding.Converter>
                     <WpfApplication1:TrueToFalseConverter/>
                 </Binding.Converter>
             </Binding>
         </Button.IsEnabled>
     </Button>
    public class TrueToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool) value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
    public class MyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult((value as string).Length == 10, null);
        }
    }
