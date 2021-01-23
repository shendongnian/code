            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            using System.Windows;
            using System.Windows.Controls;
            using System.Windows.Data;
            using System.Windows.Documents;
            using System.Windows.Input;
            using System.Windows.Media;
            using System.Windows.Media.Imaging;
            using System.Windows.Navigation;
            using System.Windows.Shapes;
            using System.Windows.Markup;
            
            namespace Infinity.Shell.Controls.Docking
            {
                /// <summary>
                /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
                ///
                /// Step 1a) Using this custom control in a XAML file that exists in the current project.
                /// Add this XmlNamespace attribute to the root element of the markup file where it is 
                /// to be used:
                ///
                ///     xmlns:MyNamespace="clr-namespace:Infinity.Shell.Controls.Docking"
                ///
                ///
                /// Step 1b) Using this custom control in a XAML file that exists in a different project.
                /// Add this XmlNamespace attribute to the root element of the markup file where it is 
                /// to be used:
                ///
                ///     xmlns:MyNamespace="clr-namespace:Infinity.Shell.Controls.Docking;assembly=Infinity.Shell.Controls.Docking"
                ///
                /// You will also need to add a project reference from the project where the XAML file lives
                /// to this project and Rebuild to avoid compilation errors:
                ///
                ///     Right click on the target project in the Solution Explorer and
                ///     "Add Reference"->"Projects"->[Browse to and select this project]
                ///
                ///
                /// Step 2)
                /// Go ahead and use your control in the XAML file.
                ///
                ///     <MyNamespace:SplitContainer/>
                ///
                /// </summary>
                
                public class SplitContainer : Control
                {
                    public Orientation Orientation
                    {
                        get { return (Orientation)GetValue(OrientationProperty); }
                        set { SetValue(OrientationProperty, value); }
                    }
            
                    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
                    public static readonly DependencyProperty OrientationProperty =
                        DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SplitContainer), new PropertyMetadata(Orientation.Horizontal));
            
                    public UIElement FirstChild
                    {
                        get { return (UIElement)GetValue(FirstChildProperty); }
                        set { SetValue(FirstChildProperty, value); }
                    }
            
                    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
                    public static readonly DependencyProperty FirstChildProperty =
                        DependencyProperty.Register("FirstChild", typeof(UIElement), typeof(SplitContainer), new PropertyMetadata(null));
            
                    public UIElement SecondChild
                    {
                        get { return (UIElement)GetValue(SecondChildProperty); }
                        set { SetValue(SecondChildProperty, value); }
                    }
            
                    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
                    public static readonly DependencyProperty SecondChildProperty =
                        DependencyProperty.Register("SecondChild", typeof(UIElement), typeof(SplitContainer), new PropertyMetadata(null));
            
            
                    static SplitContainer()
                    {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitContainer), new FrameworkPropertyMetadata(typeof(SplitContainer)));
                    }
            
                    public override void OnApplyTemplate()
                    {
                        base.OnApplyTemplate();
                    }
                }
            }
        
            <Style TargetType="{x:Type dock:SplitContainer}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type dock:SplitContainer}">
                            <Border Background="{TemplateBinding Background}"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}">
                                <Grid>
                                    <Grid.RowDefinitions>
                                        <RowDefinition/>
                                        <RowDefinition Height="Auto"/>
                                        <RowDefinition/>
                                    </Grid.RowDefinitions>
                                    
                                    <Grid.ColumnDefinitions> <!--Horizontal -->
                                        <ColumnDefinition/>
                                        <ColumnDefinition Width="Auto"/>
                                        <ColumnDefinition/>
                                    </Grid.ColumnDefinitions>
            
                                    <Grid x:Name="PART_FirstChildGrid"
                                          Grid.Column="0"
                                          Grid.Row="0"
                                          Grid.RowSpan="3">
                                        <ContentPresenter Content="{TemplateBinding FirstChild}"/>
                                    </Grid>
                                    
                                    <GridSplitter x:Name="PART_Splitter"
                                                  Grid.Column="1"
                                                  Grid.Row="0"
                                                  Grid.RowSpan="3"
                                                  Grid.ColumnSpan="1"
                                                  Width="5"
                                                  VerticalAlignment="Stretch"
                                                  HorizontalAlignment="Center"
                                                  ShowsPreview="True"/>
            
                                    <Grid x:Name="PART_SecondChildGrid"
                                          Grid.Column="2"
                                          Grid.Row="0"
                                          Grid.RowSpan="3">
                                        <ContentPresenter Content="{TemplateBinding SecondChild}"/>
                                    </Grid>
                                </Grid>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="Orientation" Value="Vertical">
                                    <Setter TargetName="PART_FirstChildGrid" Property="Grid.Column" Value="0"/>
                                    <Setter TargetName="PART_FirstChildGrid" Property="Grid.Row" Value="0"/>
                                    <Setter TargetName="PART_FirstChildGrid" Property="Grid.ColumnSpan" Value="3"/>
                                    <Setter TargetName="PART_FirstChildGrid" Property="Grid.RowSpan" Value="1"/>
                                    
                                    <Setter TargetName="PART_Splitter" Property="Grid.Column" Value="0"/>
                                    <Setter TargetName="PART_Splitter" Property="Grid.Row" Value="1"/>
                                    <Setter TargetName="PART_Splitter" Property="Grid.ColumnSpan" Value="3"/>
                                    <Setter TargetName="PART_Splitter" Property="Grid.RowSpan" Value="1"/>
                                    <Setter TargetName="PART_Splitter" Property="VerticalAlignment" Value="Center"/>
                                    <Setter TargetName="PART_Splitter" Property="HorizontalAlignment" Value="Stretch"/>
                                    <Setter TargetName="PART_Splitter" Property="Width" Value="Auto"/>
                                    <Setter TargetName="PART_Splitter" Property="Height" Value="5"/>
            
                                    <Setter TargetName="PART_SecondChildGrid" Property="Grid.Column" Value="0"/>
                                    <Setter TargetName="PART_SecondChildGrid" Property="Grid.Row" Value="2"/>
                                    <Setter TargetName="PART_SecondChildGrid" Property="Grid.ColumnSpan" Value="3"/>
                                    <Setter TargetName="PART_SecondChildGrid" Property="Grid.RowSpan" Value="1"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        
        <Window
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:local="clr-namespace:Infinity.Shell.Controls.Text;assembly=Infinity.Shell"
                xmlns:dock="clr-namespace:Infinity.Shell.Controls.Docking;assembly=Infinity.Shell"
    x:Class="Infinity.MainWindow"
                mc:Ignorable="d"
                Title="MainWindow" Height="350" Width="499.573" Background="#FF1E1E1E">
            <Grid>
                <dock:SplitContainer Orientation="Vertical">
                    <dock:SplitContainer.FirstChild>
                        <dock:SplitContainer>
                            <dock:SplitContainer.FirstChild>
                                <Button Content="First Child Button"/>
                            </dock:SplitContainer.FirstChild>
                            <dock:SplitContainer.SecondChild>
                                <Button Content="Second Child Button"/>
                            </dock:SplitContainer.SecondChild>
                        </dock:SplitContainer>
                    </dock:SplitContainer.FirstChild>
                    <dock:SplitContainer.SecondChild>
                        <Button Content="First Splitter Second Child"/>
                    </dock:SplitContainer.SecondChild>
                </dock:SplitContainer>
            </Grid>
        
        
        </Window>
