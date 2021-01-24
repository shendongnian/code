C#
using {YourNamespace}.Extensions;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
public static class ValidationBehavior
{
	// Fields
	public static readonly BindableProperty IsActiveProperty;
	public static readonly BindableProperty HasErrorProperty;
	public static readonly BindableProperty ErrorsProperty;
	public static readonly BindableProperty PropertyNameProperty;
	// Constructor
	static ValidationBehavior()
	{
		IsActiveProperty = BindableProperty.CreateAttached("IsActive", typeof(bool), typeof(ValidationBehavior), default(bool), propertyChanged: OnIsActivePropertyChanged);
		ErrorsProperty = BindableProperty.CreateAttached("Errors", typeof(IList), typeof(ValidationBehavior), null);
		HasErrorProperty = BindableProperty.CreateAttached("HasError", typeof(bool), typeof(ValidationBehavior), default(bool));
		PropertyNameProperty = BindableProperty.CreateAttached("PropertyName", typeof(string), typeof(ChangeValidationBehavior), default(string));
	}
	// Properties
	#region IsActive Property
	public static bool GetIsActive(BindableObject obj)
	{
		return (bool)obj.GetValue(IsActiveProperty);
	}
	public static void SetIsActive(BindableObject obj, bool value)
	{
		obj.SetValue(IsActiveProperty, value);
	}
	#endregion
	#region Errors Property
	public static IList GetErrors(BindableObject obj)
	{
		return (IList)obj.GetValue(ErrorsProperty);
	}
	public static void SetErrors(BindableObject obj, IList value)
	{
		obj.SetValue(ErrorsProperty, value);
	}
	#endregion
	#region HasError Property
	public static bool GetHasError(BindableObject obj)
	{
		return (bool)obj.GetValue(HasErrorProperty);
	}
	public static void SetHasError(BindableObject obj, bool value)
	{
		obj.SetValue(HasErrorProperty, value);
	}
	#endregion
	#region PropertyName Property
	public static string GetPropertyName(BindableObject obj)
	{
		return (string)obj.GetValue(PropertyNameProperty);
	}
	public static void SetPropertyName(BindableObject obj, string value)
	{
		obj.SetValue(PropertyNameProperty, value);
	}
	#endregion
	// Methodes
	private static void OnIsActivePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if ((bool)newValue)
		{
			var binding = bindable.GetBinding(Entry.TextProperty); 
			if (binding != null)
			{
				string bindingPath = binding.Path;
				string propertyName = bindingPath.Split('.').Last();
				SetPropertyName(bindable, propertyName);
				bindable.BindingContextChanged += Bindable_BindingContextChanged;
			}
		}
		else
		{
			SetPropertyName(bindable, null);
			bindable.BindingContextChanged -= Bindable_BindingContextChanged;
		}
	}
	private static void Bindable_BindingContextChanged(object sender, EventArgs e)
	{
		var bindable = sender as BindableObject;
		if (bindable == null)
			return;
		var errorInfo = bindable.BindingContext as INotifyDataErrorInfo;
		if (errorInfo == null)
			return;
		// NB! Not sure if this will create memory leak
		errorInfo.ErrorsChanged += (s, ea) =>
		{
			if (ea.PropertyName != GetPropertyName(bindable))
				return;
			var info = s as INotifyDataErrorInfo;
			if (info == null)
				return;
			if (!info.HasErrors)
			{
				SetErrors(bindable, null);
				SetHasError(bindable, false);
			}
			else
			{
				var foundErrors = info.GetErrors(ea.PropertyName);
				if (foundErrors == null)
				{
					SetErrors(bindable, null);
					SetHasError(bindable, false);
				}
				else
				{
					SetErrors(bindable, foundErrors.Cast<string>().ToList());
					SetHasError(bindable, true);
				}
			}
		};
	}
}
This may not be the "right way" to do it, but it works.
Any insights or improvements to the code would be much appreciated.
Hope it helps somebody:)
