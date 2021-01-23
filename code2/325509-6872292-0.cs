    public Sprite Sprite
    {
        get { return (Quiz.Sprite)GetValue(SpriteProperty); }
        set { SetValue(SpriteProperty, value); }
    }
    private static void OnSpritPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var control = d as YourControl;
        var sprite = e.NewValue as Quiz.Sprite;
        control.spriteBrush.ImageSource = new BitmapImage(new Uri("/Project;component/" + sprite.spriteSheet, UriKind.RelativeOrAbsolute));
        control.spriteTransform.TranslateX = -558;
        control.spriteTransform.TranslateY = 0;
    }
    public static DependencyProperty SpriteProperty = DependencyProperty.Register(
       "Sprite", typeof(Sprite), typeof(spriteView),
        new PropertyMetadata(new Quiz.Sprite() { spriteSheet = "wp7_buttons.png" }, OnSpritPropertyValueChanged));
