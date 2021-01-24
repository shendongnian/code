    public static class FluentValidationExtendions
    {
        public static IRuleBuilderOptions<T, TProperty> NotEmptyWithDefaultCode<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorCode = null)
        {
            return ruleBuilder.NotEmpty().WithErrorCode(errorCode ?? errorCodes['EmptyField']);
        }
    }
