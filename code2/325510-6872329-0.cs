    public Sprite Sprite
    {
        get { return (Quiz.Sprite)GetValue(SpriteProperty); }
        set { SetValue(SpriteProperty, value); }
    }
    public static DependencyProperty SpriteProperty = DependencyProperty.Register(
    "Sprite", typeof(Sprite), typeof(SpriteView), new PropertyMetadata(new Quiz.Sprite() { spriteSheet = "wp7_buttons.png" },
    SpriteChanged));
    private static void SpriteChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        SpriteView view = sender as SpriteView;
        Sprite sprite = e.NewValue as Sprite;
        if (view != null && sprite != null)
        {
            view.spriteBrush.ImageSource = new BitmapImage(new Uri("/Project;component/" + sprite.spriteSheet, UriKind.RelativeOrAbsolute));
            view.spriteTransform.TranslateX = -558;
            view.spriteTransform.TranslateY = 0;
        }
    }
