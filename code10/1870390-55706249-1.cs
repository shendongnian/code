    public class CurrencyModelBinder : IModelBinder
    {
        private static readonly Currency[] _currencies = new Currency[]
        {
            Currency.EUR,
            Currency.USD,
        };
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var providerResult = bindingContext.ValueProvider.GetValue(modelName);
            if (providerResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            var value = providerResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }
            var currency = _currencies
                .FirstOrDefault(c => c.Code.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (currency != null)
                bindingContext.Result = ModelBindingResult.Success(currency);
            else
                bindingContext.ModelState.TryAddModelError(modelName, "Unknown currency");
            return Task.CompletedTask;
        }
    }
