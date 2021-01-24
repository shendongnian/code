private void FormSubmitted(EditContext context)
{
  ...
}
If you use the following extension you can use the following code in your `FormSubmitted` method and it will not only validate your entire object tree but also update your UI according to the result.
{
  if (context.ValdiateObjectTree())
  {
    ... do whatever
  }
}
The extension...
using Microsoft.AspNetCore.Components.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace PeterLeslieMorris.Blazor.Validation.Extensions
{
	public static class EditContextExtensions
	{
		static PropertyInfo IsModifiedProperty;
		static MethodInfo GetFieldStateMethod;
		/// <summary>
		/// Validates an entire object tree
		/// </summary>
		/// <param name="editContext">The EditContext to validate the Model of</param>
		/// <returns>True if valid, otherwise false</returns>
		public static bool ValidateObjectTree(this EditContext editContext)
		{
			var validatedObjects = new HashSet<object>();
			ValidateObject(editContext, editContext.Model, validatedObjects);
			editContext.NotifyValidationStateChanged();
			return !editContext.GetValidationMessages().Any();
		}
		public static void ValidateProperty(this EditContext editContext, FieldIdentifier fieldIdentifier)
		{
			if (fieldIdentifier.Model == null)
				return;
			var propertyInfo = fieldIdentifier.Model.GetType().GetProperty(
				fieldIdentifier.FieldName,
				BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
			var validatedObjects = new HashSet<object>();
			ValidateProperty(editContext, fieldIdentifier.Model, propertyInfo, validatedObjects);
		}
		private static void ValidateObject(
			EditContext editContext,
			object instance,
			HashSet<object> validatedObjects)
		{
			if (instance == null)
				return;
			if (validatedObjects.Contains(instance))
				return;
			if (instance is IEnumerable && !(instance is string))
			{
				foreach (object value in (IEnumerable)instance)
					ValidateObject(editContext, value, validatedObjects);
				return;
			}
			if (instance.GetType().Assembly == typeof(string).Assembly)
				return;
			validatedObjects.Add(instance);
			var properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			foreach (PropertyInfo property in properties)
				ValidateProperty(editContext, instance, property, validatedObjects);
		}
		private static void ValidateProperty(
			EditContext editContext,
			object instance,
			PropertyInfo property,
			HashSet<object> validatedObjects)
		{
			NotifyPropertyChanged(editContext, instance, property.Name);
			object value = property.GetValue(instance);
			ValidateObject(editContext, value, validatedObjects);
		}
		private static void NotifyPropertyChanged(
			EditContext editContext,
			object instance,
			string propertyName)
		{
			if (GetFieldStateMethod == null)
			{
				GetFieldStateMethod = editContext.GetType().GetMethod(
					"GetFieldState",
					BindingFlags.NonPublic | BindingFlags.Instance);
			}
			var fieldIdentifier = new FieldIdentifier(instance, propertyName);
			object fieldState = GetFieldStateMethod.Invoke(editContext, new object[] { fieldIdentifier, true });
			if (IsModifiedProperty == null)
			{
				IsModifiedProperty = fieldState.GetType().GetProperty(
					"IsModified",
					BindingFlags.Public | BindingFlags.Instance);
			}
			object originalIsModified = IsModifiedProperty.GetValue(fieldState);
			editContext.NotifyFieldChanged(fieldIdentifier);
			IsModifiedProperty.SetValue(fieldState, originalIsModified);
		}
	}
}
You can find the extension source [here][1]. You could alternatively use [Blazor-Validation][2], which also allows you to use [FluentValidation][3].
If you want a more in-depth understanding of how Blazor forms / validation works, you can read about it in this section of [Blazor University][4].
  [1]: https://github.com/mrpmorris/blazor-validation/blob/master/src/PeterLeslieMorris.Blazor.Validation/Extensions/EditContextExtensions.cs
  [2]: https://github.com/mrpmorris/blazor-validation
  [3]: https://fluentvalidation.net/
  [4]: https://blazor-university.com/forms/
