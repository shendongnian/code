    public class SupplierTransactionsValidation : AbstractValidator<SageStandardImportInvoces>
    {
        public SupplierTransactionsValidation()
        {
            BuildRule(x => x.AnalysisCode1);
            BuildRule(x => x.AnalysisCode2);
            BuildRule(x => x.AnalysisCode3);
        }
        private IRuleBuilderOptions<SageStandardImportInvoces, string> 
            BuildRule(System.Linq.Expressions.Expression<Func<SageStandardImportInvoces, string>> expression)
        {
            return RuleFor(expression)
                .NotEqual("None")
                .WithMessage($"Please enter a value for {(expression.Body as System.Linq.Expressions.MemberExpression)?.Member.Name}")
                .Length(0, 3);
        }
    }
