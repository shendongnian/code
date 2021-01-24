    public static readonly DependencyProperty ReferencedButtonProperty=
            DependencyProperty.Register(nameof(ReferencedButton),
                    typeof(UIElement),
                    typeof(MyUserControl),
                    new PropertyMetadata(default(UIElement),
                    new PropertyChangedCallback(PlacementCallBack)));
