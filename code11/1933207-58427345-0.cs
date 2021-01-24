csharp
public static BindableProperty CustomTitleProperty = BindableProperty.Create(
    propertyName: nameof(CustomTitle),
    returnType: typeof(string),
    declaringType: typeof(CustomEditor),
    defaultValue: null);
public string CustomTitle
{
    get { return (string)GetValue(CustomTitleProperty); }
    set { SetValue(CustomTitleProperty, value); }
}
protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
{
    base.OnPropertyChanged(propertyName);
    if(propertyName==CustomTitleProperty.PropertyName)
    {
        SetCustomTitle();
    }
}
private void SetCustomTitle()
{
    switch(Device.RuntimePlatform)
    {
        case Device.iOS:
            {
                PlainText = CustomTitle;
                return;
            }
        case Device.Android:
            {
                Text = CustomTitle;
                return;
            }
        default:
            {
                throw new NotSupportedException($"{Device.RuntimePlatform} not supported in {nameof(SetCustomTitle)}");
            }
    }
}
What I did there is I simply moved OnPlatform code to your control, so you can keep your xaml code cleaner.
With this approach you should be able to use it like
xaml
<controls:CustomEditor HeightRequest="80" IsPassword="True" CustomTitle="{Binding KeyString}">
     <controls:CustomEditor.Effects>
         <controls:PasswordEffect/>
     </controls:CustomEditor.Effects>
</controls:CustomEditor>
