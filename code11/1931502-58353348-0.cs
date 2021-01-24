csharp
public static BindableProperty ConfirmedCommandProperty = BindableProperty.Create(
    propertyName: nameof(ConfirmedCommand),
    returnType: typeof(ICommand),
    declaringType: typeof(YourPickerClass),
    defaultValue: null);
public ICommand ConfirmedCommand
{
    get { return (ICommand)GetValue(ConfirmedCommandProperty); }
    set { SetValue(ConfirmedCommandProperty, value); }
}
to your picker. Then you can bind on a view layer. 
