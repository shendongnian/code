    public partial class UML : UserControl
        {
            public UML()
            {
                InitializeComponent();
    
                SetupData();
            }
    
            #region Set up data
    
            public void SetupData()
            {
                Brush b = new SolidColorBrush(Colors.DarkGray);
                AddArrow(this.LayoutRoot, 50, 250, 200, b, 2.0);
    
                var classes = new List<Class>(
                    new Class[]
                    {
                        new Class { Name = "Line", Methods= new string[] { "Draw", "setColor"} , X=10, Y=11, IsExpanded=true},
                        new Class { Name = "Rectangle", Methods = new string[] { "Draw", "setColor", "setFill"}, X=200, Y=200, IsExpanded=true},
                        new Class { Name = "Circle", Methods = new string[] {"Draw", "setColor", "setFill", "setRadius"}, X=10, Y=200, IsExpanded=false},
                    });
    
                this.DataContext = classes;
    
            }
    
            #endregion
    
    
            private void AddArrow(Grid grid, double startX, double startY, double length, Brush lineBrush, double thickness)
            {
                Line baseline = CreateBaseLine(startX, startY, length, lineBrush, thickness);
                grid.Children.Insert(0, baseline);
                grid.Children.Insert(0, CreateLeftArrowHead(lineBrush, thickness, baseline));
                grid.Children.Insert(0, CreateRightArrowHead(lineBrush, thickness, baseline));
    
            }
    
            #region Arrow http://www.kunal-chowdhury.com/2010/01/how-to-create-simple-arrow-in.html
    
            private static Line CreateBaseLine(double startX, double startY, double length, Brush lineBrush, double thickness)
            {
                Line arrowLine = new Line();
                arrowLine.Stroke = lineBrush;
                arrowLine.StrokeThickness = thickness;
                arrowLine.X1 = startX;
                arrowLine.X2 = length;
                arrowLine.Y1 = startY;
                arrowLine.Y2 = startY;
                return arrowLine;
            }
            private static Line CreateLeftArrowHead(Brush lineBrush, double thickness, Line arrowLine)
            {
                Line arrowLeft = new Line();
                arrowLeft.Stroke = lineBrush;
                arrowLeft.StrokeThickness = thickness;
                arrowLeft.X1 = arrowLine.X2 - 10.00;
                arrowLeft.X2 = arrowLine.X2;
                arrowLeft.Y1 = arrowLine.Y2 - 10.00;
                arrowLeft.Y2 = arrowLine.Y2;
                return arrowLeft;
            }
    
            private static Line CreateRightArrowHead(Brush lineBrush, double thickness, Line arrowLine)
            {
                Line arrowRight = new Line();
                arrowRight.Stroke = lineBrush;
                arrowRight.StrokeThickness = thickness;
                arrowRight.X1 = arrowLine.X2 - 10.00;
                arrowRight.X2 = arrowLine.X2;
                arrowRight.Y1 = arrowLine.Y2 + 10.00;
                arrowRight.Y2 = arrowLine.Y2;
                return arrowRight;
            }
            #endregion
        }
    
        public class Class
        {
            public string Name { get; set; }
            public IEnumerable<string> Methods { get; set; }
    
            public double X { get; set; }
            public double Y { get; set; }
            public bool IsExpanded { get; set; }
        }
    <UserControl x:Class="SlBug1.UML"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        d:DesignHeight="300" d:DesignWidth="400">
    
        <Grid x:Name="LayoutRoot" Background="White">
    
            <Canvas>
                <ItemsControl x:Name="UmlCanvas" ItemsSource="{Binding}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <!-- Hack: http://forums.silverlight.net/post/370493.aspx -->
                            <Canvas>
                                <Border Background="LightBlue"
                                Canvas.Left="{Binding X}"
                                Canvas.Top="{Binding Y}"
                                BorderBrush="Black" BorderThickness="2" >
                                    <StackPanel>
                                        <TextBlock Text="{Binding Name}" FontSize="16" />
                                        <ItemsControl 
                                            ItemsSource="{Binding Methods}" 
                                            Margin="10,10,0,0"/>
                                    </StackPanel>
                                </Border>
                            </Canvas>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </Canvas>
        </Grid>
    </UserControl>
