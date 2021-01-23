    namespace SlBug1
    {
        using System.Collections.Generic;
        using System.Windows.Controls;
        using System.Windows.Media;
        using System.Windows.Shapes;
    
        public partial class UML : UserControl
        {
            public UML()
            {
                InitializeComponent();
    
                SetupData();
    
                this.DataContext = this;
            }
    
            public object Classes { get; set; }
            public object Arrows { get; set; }
    
            #region Set up data
    
            public void SetupData()
            {
    
                var arrows = new List<Arrow>(
    
                    new Arrow[] {
                        new Arrow(50, 250, 200, 250),
                        new Arrow(50, 50, 200, 220)
                    }
                );
    
                this.Arrows = arrows;
    
                var classes = new List<Class>(
                    new Class[]
                    {
                        new Class { Name = "Line", Methods= new string[] { "Draw", "setColor"} , X=10, Y=11, IsExpanded=true},
                        new Class { Name = "Rectangle", Methods = new string[] { "Draw", "setColor", "setFill"}, X=200, Y=200, IsExpanded=true},
                        new Class { Name = "Circle", Methods = new string[] {"Draw", "setColor", "setFill", "setRadius"}, X=10, Y=200, IsExpanded=false},
                    });
    
                this.Classes = classes;
    
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
    
        public class Arrow
        {
            public Arrow(double X1, double Y1, double X2, double Y2)
            {
                this.X1 = X1; this.Y1 = Y1;
                this.X2 = X2; this.Y2 = Y2;
            }
    
            public double X1 { get; set; }
            public double Y1 { get; set; }
            public double X2 { get; set; }
            public double Y2 { get; set; }
            public double LX1 { get { return (14 * X2 + X1) / 15; } }
            public double RX1 { get { return (14 * X2 + X1) / 15; } }
            public double LY1 { get { return (14 * Y2 + Y1) / 15 - 10; } }
            public double RY1 { get { return (14 * Y2 + Y1) / 15 + 10; } }
        }
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
                <ItemsControl x:Name="ArrowsCanvas" ItemsSource="{Binding Arrows}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Canvas>
                                <Line X1="{Binding X1}" X2="{Binding X2}"
                                      Y1="{Binding Y1}" Y2="{Binding Y2}" Stroke="Black" />
                                <Line X1="{Binding LX1}" X2="{Binding X2}"
                                      Y1="{Binding LY1}" Y2="{Binding Y2}" Stroke="Black" />
                                <Line X1="{Binding RX1}" X2="{Binding X2}"
                                      Y1="{Binding RY1}" Y2="{Binding Y2}" Stroke="Black" />
                            </Canvas>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
                <ItemsControl x:Name="UmlCanvas" ItemsSource="{Binding Classes}">
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
