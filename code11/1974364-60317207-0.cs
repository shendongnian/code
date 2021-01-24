using System.Globalization;
using System.Windows.Controls;
namespace ZasobyIT
{
    class DateTimeWalidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "aaa")
                return new ValidationResult(false, $"Error: value = aaa");
            return ValidationResult.ValidResult;
        }
    }
}
