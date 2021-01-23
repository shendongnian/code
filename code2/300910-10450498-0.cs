public sealed class DateTimeBinder : IModelBinder
{
	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
	{
		if (controllerContext == null)
		{
			throw new ArgumentNullException("controllerContext");
		}
		if (bindingContext == null)
		{
			throw new ArgumentNullException("bindingContext");
		}
		var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
		bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
		if (valueProviderResult == null)
		{
			return null;
		}
		var attemptedValue = valueProviderResult.AttemptedValue;
		return ParseDateTimeInfo(bindingContext, attemptedValue);
	}
	private static DateTime? ParseDateTimeInfo(ModelBindingContext bindingContext, string attemptedValue)
	{
		if (string.IsNullOrEmpty(attemptedValue))
		{
			return null;
		}
		if (!Regex.IsMatch(attemptedValue, @"^\d{2}-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)-\d{4}$", RegexOptions.IgnoreCase))
		{
			var displayName = bindingContext.ModelMetadata.DisplayName;
			var errorMessage = string.Format("{0} must be in the format DD-MMM-YYYY", displayName);
			bindingContext.ModelState.AddModelError(bindingContext.ModelMetadata.PropertyName, errorMessage);
			return null;
		}
		return DateTime.Parse(attemptedValue);
	}
}
