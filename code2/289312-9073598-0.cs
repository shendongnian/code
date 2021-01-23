    using System.CodeDom.Compiler;
    using System.Windows.Controls;
    using Microsoft.CSharp;
    using System.Text.RegularExpressions;
    
    namespace Com.Gmail.Birklid.Ray.CodeGeneratorTemplateDialog
    {
        public class NamespaceValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                var input = value as string;
                if (string.IsNullOrWhiteSpace(value as string))
                {
                    return new ValidationResult(false, "A namespace must be provided.");
                }
                else if (this.doubleDot.IsMatch(input))
                {
                    return new ValidationResult(false, "'..' is not valid.");
                }
                var inputs = (value as string).Split('.');
                foreach (var item in inputs)
                {
                    if (!compiler.IsValidIdentifier(item))
                    {
                        return new ValidationResult(false, string.Format(cultureInfo, "'{0}' is invalid.", item));
                    }
                }
                return ValidationResult.ValidResult;
            }
    
            private readonly CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
            private readonly Regex doubleDot = new Regex("\\.\\.");
        }
    }
