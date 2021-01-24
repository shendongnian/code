<UserControl x:Class="cs_wpf_test_1.ArrowButton"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:cs_wpf_test_1"
             mc:Ignorable="d" 
             d:DesignHeight="120" d:DesignWidth="175"
             Loaded="UserControl_Loaded">
    <Button Name="MyButton" Focusable="False" Padding="0,0,0,0">
        <Button.Resources>
            <Style x:Key="styleWithPlusSign">
                <Style.Triggers>
                    <Trigger Property="Grid.Row" Value="0">
                        <Setter Property="Path.Data" Value="M 5,95 L 95,95 50,5 5,95"></Setter>
                    </Trigger>
                    <Trigger Property="Grid.Row" Value="1">
                        <Setter Property="Path.Data" Value="M 50,10 L 50,10 L 50,90 M 10,50 L 90,50"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
            <Style x:Key="styleWithMinusSign">
                <Style.Triggers>
                    <Trigger Property="Grid.Row" Value="0">
                        <Setter  Property="Path.Data" Value="M 5,5 L 50,50 95,5 5,5"></Setter>
                    </Trigger>
                    <Trigger Property="Grid.Row" Value="1">
                        <Setter Property="Path.Data" Value="M 10,50 L 90,50"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Button.Resources>
        <Button.Template>
            <ControlTemplate TargetType="{x:Type Button}">
                <Border Background="{TemplateBinding Background}"
                         BorderBrush="{TemplateBinding BorderBrush}"
                         BorderThickness="{TemplateBinding BorderThickness}">
                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates" CurrentStateChanged="CommonStates_CurrentStateChanged">
                            <VisualState x:Name="Normal" />
                            <VisualState x:Name="MouseOver" />
                            <VisualState x:Name="Pressed" />
                            <VisualState x:Name="Disabled" />
                        </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <Path Stroke="Blue"
                              Stretch="Fill"
                              x:Name="MyFirstPath"
                              Style="{StaticResource styleWithPlusSign}"
                              Grid.Row="0"/>
                        <Path Stroke="Black"
                              StrokeThickness="1"
                              Stretch="Uniform"
                              x:Name="MySecondPath"
                              Style="{Binding ElementName=MyFirstPath, Path=Style}"
                              Grid.Row="1"/>
                    </Grid>
                </Border>
            </ControlTemplate>
        </Button.Template>
    </Button>
</UserControl>
**My code-behind:**
    /// <summary>
    /// Interaction logic for ArrowButton.xaml
    /// </summary>
    public partial class ArrowButton : UserControl
    {
        internal Path MyTemplateSecondPath,
            MyTemplateFirstPath;
        public ArrowButton()
        {
            InitializeComponent();
            // TODO: use smth like MyButton.PropertyChanged to set this:
            MyButton.Margin = new Thickness(
                -MyButton.BorderThickness.Left,
                -MyButton.BorderThickness.Top,
                -MyButton.BorderThickness.Right,
                -MyButton.BorderThickness.Bottom);
        }
        public bool State
        {
            get
            {
                return (bool)GetValue(StateProperty);
            }
            set
            {
                SetValue(StateProperty, value);
            }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(bool),
                typeof(ArrowButton), new PropertyMetadata(true, new PropertyChangedCallback(OnStateChanged)));
        private static void OnStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var b = d as ArrowButton;
            b.MyButton.ApplyTemplate();
            b.MyTemplateFirstPath = (Path)b.MyButton.Template.FindName("MyFirstPath", b.MyButton);
            if (b.State)
            {
                // plus
                b.MyTemplateFirstPath.Style = b.MyButton.FindResource("styleWithPlusSign") as Style;
            }
            else
            {
                // minus
                b.MyTemplateFirstPath.Style = b.MyButton.FindResource("styleWithMinusSign") as Style;
            }
        }
        internal void SetPseudofocused(bool p)
        {
            if (p)
            {
                BorderBrush = Brushes.Blue;
            }
            else
            {
                BorderBrush = Brushes.Transparent;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyTemplate();
            MyTemplateSecondPath = (Path)MyButton.Template.FindName("MySecondPath", MyButton);
            UpdateMyLayout();
        }
        private void CommonStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            var btn = e.Control as Button;
            if (e.NewState.Name == "MouseOver")
            {
                btn.Background = Brushes.White;
            }
            else if (e.NewState.Name == "Pressed")
            {
                btn.Background = Brushes.LightBlue;
            }
            else if (e.NewState.Name == "Disabled")
            {
                btn.Background = Brushes.Gray;
            }
            else
            {
                btn.Background = (Brush)MyButton.FindResource(SystemColors.ControlBrushKey);
            }
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == WidthProperty ||
                e.Property == HeightProperty ||
                e.Property == BorderThicknessProperty)
            {
                UpdateMyLayout();
            }
        }
        internal void UpdateMyLayout()
        {
            if (MyTemplateSecondPath == null)
            {
                return;
            }
            // update focus border size:
            double v = ActualHeight / 25d;
            BorderThickness = new Thickness(v, v, v, v);
            double min = Math.Min(ActualWidth, ActualHeight);
            if (State)
            {
                MyTemplateSecondPath.Margin = new Thickness(
                    min / 5,
                    min / 5,
                    min / 5,
                    min / 5);
            }
            else
            {
                MyTemplateSecondPath.Margin = new Thickness(
                    min / 2.2,
                    min / 2.2,
                    min / 2.2,
                    min / 2.2);
            }
        }
    }
