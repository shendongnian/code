     <Window x:Class="WpfApplication1.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                Title="MainWindow" Height="350" Width="525">
            <Grid>
                <Label Name="lblContent" VerticalAlignment="Center" FontSize="14">
                    <Label.Style>
                        <Style TargetType="Label">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=IsLink}"
                                                              Value="True">
                                    <Setter Property="Foreground" Value="Blue" />
                                    <Setter Property="Cursor" Value="Hand" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </Label.Style>
                    label's text
                </Label>
        
            </Grid>
        </Window>
    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
    
    
            public Boolean IsLink
            {
                get { return (Boolean)GetValue(IsLinkProperty); }
                set { SetValue(IsLinkProperty, value); }
            }
    
            public static readonly DependencyProperty IsLinkProperty =
                DependencyProperty.Register("IsLink", typeof(Boolean),
                typeof(MainWindow), new UIPropertyMetadata(false));
    
            
        }
