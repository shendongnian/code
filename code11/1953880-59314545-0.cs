<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <ListBox x:Name="listBox" ItemsSource="{Binding}" BorderBrush="Transparent" HorizontalContentAlignment="Stretch">
            
            <!--Remove the hover and select style of the list view because we aren't using the list in that way-->
            <ListBox.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                    <Setter Property="Foreground" Value="Black"/>
                    <Setter Property="FontSize" Value="12"/>
                    <Setter Property="FontFamily" Value="Arial"/>
                    <Setter Property="Padding" Value="3"/>
                    <Setter Property="HorizontalContentAlignment" Value="Left"/>
                    <Setter Property="VerticalContentAlignment" Value="Top"/>
                    <Setter Property="Background" Value="Transparent"/>
                    <Setter Property="BorderThickness" Value="0"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListBoxItem">
                                <Grid Background="{TemplateBinding Background}">
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="CommonStates">
                                            <VisualState x:Name="Normal"/>
                                            <VisualState x:Name="MouseOver">
                                                <Storyboard>
                                                    <DoubleAnimation Duration="0" To=".35" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="fillColor"/>
                                                </Storyboard>
                                            </VisualState>
                                            <VisualState x:Name="Disabled">
                                                <Storyboard>
                                                    <DoubleAnimation Duration="0" To=".55" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="contentPresenter"/>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="SelectionStates">
                                            <VisualState x:Name="Unselected"/>
                                            <VisualState x:Name="Selected"/>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="FocusStates">
                                            <VisualState x:Name="Focused"/>
                                            <VisualState x:Name="Unfocused"/>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                    <Rectangle x:Name="fillColor" IsHitTestVisible="False" Opacity="0" RadiusY="1" RadiusX="1"/>
                                    <Rectangle x:Name="fillColor2" IsHitTestVisible="False" Opacity="0" RadiusY="1" RadiusX="1"/>
                                    <ContentPresenter x:Name="contentPresenter" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}"/>
                                    <Rectangle x:Name="FocusVisualElement" RadiusY="1" RadiusX="1" StrokeThickness="1" Visibility="Collapsed"/>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListBox.ItemContainerStyle>
            
            <!--Setup the design that we have for our buttons-->
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="4">
                        <Button Content="{Binding}" FontWeight="Bold"  >
                            <Button.Style>
                                <Style TargetType="{x:Type Button}">
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="{x:Type Button}">
                                                <Border Background="{TemplateBinding Background}" BorderBrush="Black" BorderThickness="1">
                                                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                                </Border>
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                    <Style.Triggers>
                                        <Trigger Property="IsMouseOver" Value="True">
                                            <Setter Property="Background" Value="Red"/>
                                        </Trigger>
                                    </Style.Triggers>
                                </Style>
                            </Button.Style>
                        </Button>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
</Window>
**MainWindow.xaml.cs**
using System;
using System.Collections.Generic;
using System.Windows;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            //Add the buttons to the list
            items.Add("test");
            items.Add("test1");
            items.Add("test2");
            items.Add("test3");
            //Update the item source of the list view
            //This should probably be done properly with bindings but the main question was about the xaml
            listBox.ItemsSource = items;
        }
    }
}
And here you can see the [result][2]
  [1]: https://www.wpftutorial.net/DataTemplates.html
  [2]: https://gyazo.com/043cb5a57cc419f274b3926d551d6d81
