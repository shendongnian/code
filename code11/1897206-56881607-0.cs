    public partial class CustomView : ContentView
     {
       public CustomView()
        {
        InitializeComponent();
        }
    public string CustomImageSource
    {
        set => SetValue(CustomImageSourceProperty, value);
        get => (string)GetValue(CustomImageSourceProperty);
    }
    public readonly static BindableProperty CustomImageSourceProperty = BindableProperty.Create(nameof(CustomImageSource), 
                                                                                            typeof(string), 
                                                                                            typeof(CustomView), 
                                                                                            defaultValue: string.Empty,
                                                                                            propertyChanged: (bindableObject, oldValue, newValue) =>
                                                                                            {
                                                                                                ((CustomView)bindableObject).MyImage.Source = ImageSource.FromFile((string)newValue);
                                                                                            });
    }
