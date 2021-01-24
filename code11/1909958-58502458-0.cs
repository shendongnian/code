    public class ShellItemGrid : Grid
    {
        public static readonly BindableProperty SelectedColorProperty =       BindableProperty.Create("SelectedColor", typeof(Color), typeof(ShellItemGrid),Color.Transparent);
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }
    }
