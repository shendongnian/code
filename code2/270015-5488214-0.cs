    <Style TargetType="{x:Type local:MyUserControl}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:MyUserControl}">
                    <Border Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                        <TextBox Width="{TemplateBinding Size}"/>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    public class MyUserControl : Control
    {
        static MyUserControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyUserControl), new FrameworkPropertyMetadata(typeof(MyUserControl)));
        }
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(MyUserControl), new UIPropertyMetadata(20));
    }
