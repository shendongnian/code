public class ValidatePesel : ValidationAttribute
{
    public string errorLenght = "Długość numeru PESEL musi zawierać 11 cyfr";
    public string errorPesel = "numer PESEL jest niepoprawny";
    public string errorType = "Podana wartość nie jest numerem PESEL";
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string pesel = value.ToString();
        if (!decimal.TryParse(pesel, out decimal result_status)) return new ValidationResult(errorType);
        if (pesel.Length == 11)
        {
            int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;
            int controlNum = int.Parse(pesel.Substring(10, 1));
            for (int i = 0; i < weight.Length; i++)
            {
                sum += int.Parse(pesel.Substring(i, 1)) * weight[i];
            }
            sum = sum % 10;
            if (10 - sum == controlNum) return ValidationResult.Success;
            else return new ValidationResult(errorPesel);
        }
        else return new ValidationResult(errorLenght);
    }
}
