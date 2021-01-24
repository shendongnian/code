<Entry Placeholder="Enter forename here" 
       Text="{Binding User.Forename, Mode=TwoWay}" 
       local:Validation.Errors="{Binding User.Errors[Forename]}" />
The Validation attached behavior gets and sets the Errors **BindableProperty**. The `User.Errors` property is provided by the ValidatableBase class, from which all model classes derive, and is an instance of the Validator class. The indexer of the Validator class returns a ReadOnlyCollection of error strings, to retrieve any validation errors for the Forename property. 
public static class Validation
{
    public static readonly BindableProperty ErrorsProperty =
        BindableProperty.CreateAttached(
            "Errors",
            typeof(ReadOnlyCollection<string>),
            typeof(Validation),
            Validator.EmptyErrorsCollection,
            propertyChanged: OnPropertyErrorsChanged);
    public static ReadOnlyCollection<string> GetErrors(BindableObject element)
    {
        return (ReadOnlyCollection<string>)element.GetValue(ErrorsProperty);
    }
    public static void SetErrors(BindableObject element, ReadOnlyCollection<string> value)
    {
        element.SetValue(ErrorsProperty, value);
    }
    static void OnPropertyErrorsChanged(BindableObject element, object oldValue, object newValue)
    {
        var view = element as View;
        if (view == null | oldValue == null || newValue == null)
        {
            return;
        }
        var propertyErrors = (ReadOnlyCollection<string>)newValue;
        if (propertyErrors.Any())
        {
            view.Effects.Add(new BorderEffect());
        }
        else
        {
            var effectToRemove = view.Effects.FirstOrDefault(e => e is BorderEffect);
            if (effectToRemove != null)
            {
                view.Effects.Remove(effectToRemove);
            }
        }
    }
}
For the full code you can access the [sample][1] on github.
  [1]: https://github.com/davidbritch/xamarin-forms/tree/master/Validation/MVVMUtopia/Views
