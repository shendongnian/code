    <Window x:Class="WpfApp1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApp1"
            mc:Ignorable="d"
            Title="MainWindow" Height="348" Width="483" PreviewMouseDown="Window_PreviewMouseDown">
        <StackPanel VerticalAlignment="Center">
            <Line x:Name="line1" X1="0" Y1="10" X2="200" Y2="10" Stroke="Yellow" StrokeThickness="20" Width="200" Height="20" Tag="yellow"/>
            <Line x:Name="line2" X1="0" Y1="10" X2="200" Y2="10" Stroke="Red" StrokeThickness="20" Width="200" Height="20" Tag="#red"/>
            <Line x:Name="line3" X1="0" Y1="10" X2="200" Y2="10" Stroke="Green" StrokeThickness="20" Width="200" Height="20" Tag="#green"/>
            <Line x:Name="line4" X1="0" Y1="10" X2="200" Y2="10" Stroke="Blue" StrokeThickness="20" Width="200" Height="20" Tag="#blue"/>
            <Line x:Name="line5" X1="10" Y1="20" X2="180" Y2="20" Stroke="Cyan" StrokeThickness="20" Width="200" Height="40" Tag="cyan" MouseDown="Line_MouseDown"/>
            <Line x:Name="line6" X1="10" Y1="20" X2="180" Y2="20" Stroke="Magenta" StrokeThickness="20" Width="200" Height="40" Tag="magenta" MouseDown="Line_MouseDown"/>
            <Grid Width="200" Height="40" MouseDown="Grid_MouseDown" Background="Transparent">
                <Line x:Name="line7" X1="10" Y1="10" X2="180" Y2="10" Stroke="Black" StrokeThickness="20" Width="200" Height="20" Tag="black" IsHitTestVisible="False"/>
            </Grid>
        </StackPanel>
    </Window>
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ContextMenu m_menu = new ContextMenu();
            Line m_hitline = null;
    
            public MainWindow()
            {
                InitializeComponent();
    
                m_menu.Items.Add("hit");
                m_menu.Items.Add("MenuItem1");
                m_menu.Items.Add("MenuItem2");
            }
    
            private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                Line linehit = null;
    
                Point pthit = e.GetPosition((UIElement)sender);
    
                HitTestResult htresult = VisualTreeHelper.HitTest(this, pthit);
                linehit = htresult.VisualHit as Line;
     
                if (linehit == null)
                {
                    // Expand the hit test area by creating a geometry centered on the hit test point.
                    //
                    // You could use a RectangleGeometry if you like....or even something more complicated
    
                    EllipseGeometry expandedHitTestArea = new EllipseGeometry(pthit, 5.0, 5.0);
    
                    m_hitline = null;
    
                    // Set up a callback to receive the hit test result enumeration.
                    VisualTreeHelper.HitTest(this, null,
                        new HitTestResultCallback(MyHitTestResultCallback),
                        new GeometryHitTestParameters(expandedHitTestArea));
    
                    linehit = m_hitline;
                }
    
                if (linehit != null)
                {
                    // mouse hit directly on line so show context menu for it
                    m_menu.Items[0] = "hit " + linehit.Tag;
    
                    m_menu.IsOpen = true;
                }
            }
    
            public HitTestResultBehavior MyHitTestResultCallback(HitTestResult result)
            {
                // Retrieve the results of the hit test.
                IntersectionDetail intersectionDetail = ((GeometryHitTestResult)result).IntersectionDetail;
    
                switch (intersectionDetail)
                {
                    case IntersectionDetail.FullyContains:
                    case IntersectionDetail.FullyInside:
                    case IntersectionDetail.Intersects:
    
                        Line linethatinterestedwithhitarea = result.VisualHit as Line;
    
                        // We ignore testing against none-line visuals (you may or may not want to do that)
                        //
                        // We will only do expanded hit testing against "lines" that have set a tag beginning with #
    
                        if (linethatinterestedwithhitarea != null)
                        {
                            // We will skip "expanded" hit testing on lines that have no Tag set
                            // i.e. the Yellow lines - just shows one way to "control" which lines you want
                            // to test against....you could also compare against a predefined list of lines
                            // you know you want to add this behaviour to.
    
                            if (!string.IsNullOrEmpty(linethatinterestedwithhitarea.Tag.ToString()) && linethatinterestedwithhitarea.Tag.ToString().StartsWith("#"))
                            { 
                                m_hitline = linethatinterestedwithhitarea;
    
                                return HitTestResultBehavior.Stop;
                            }
                        }
    
                        return HitTestResultBehavior.Continue;
    
                    default:
                        return HitTestResultBehavior.Stop;
                }
            }
    
            private void Line_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Line linehit = sender as Line;
    
                if (linehit != null)
                {
                    m_menu.Items[0] = "hit " + linehit.Tag;
    
                    m_menu.IsOpen = true;
                }
            }
    
            private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
            {
                m_menu.Items[0] = "hit black";
    
                m_menu.IsOpen = true;
            }
        }
    }
