    <?xml version="1.0" encoding="utf-16"?>
    <ControlTemplate
        TargetType="TreeViewItem" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:s="clr-namespace:System;assembly=mscorlib" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition
                    Width="Auto"
                    MinWidth="19" />
                <ColumnDefinition
                    Width="Auto" />
                <ColumnDefinition
                    Width="*" />
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition
                    Height="Auto" />
                <RowDefinition />
            </Grid.RowDefinitions>
            <ToggleButton
                IsChecked="False"
                ClickMode="Press"
                Name="Expander">
                <ToggleButton.Style>
                    <Style
                        TargetType="ToggleButton">
                        <Style.Resources>
                            <ResourceDictionary />
                        </Style.Resources>
                        <Setter
                            Property="UIElement.Focusable">
                            <Setter.Value>
                                <s:Boolean>False</s:Boolean>
                            </Setter.Value>
                        </Setter>
                        <Setter
                            Property="FrameworkElement.Width">
                            <Setter.Value>
                                <s:Double>19</s:Double>
                            </Setter.Value>
                        </Setter>
                        <Setter
                            Property="FrameworkElement.Height">
                            <Setter.Value>
                                <s:Double>13</s:Double>
                            </Setter.Value>
                        </Setter>
                        <Setter
                            Property="Control.Template">
                            <Setter.Value>
                                <ControlTemplate
                                    TargetType="ToggleButton">
                                    <Border
                                        Background="#00FFFFFF"
                                        Width="19"
                                        Height="13">
                                        <Border
                                            BorderThickness="1,1,1,1"
                                            CornerRadius="1,1,1,1"
                                            BorderBrush="#FF7898B5"
                                            Width="9"
                                            Height="9"
                                            SnapsToDevicePixels="True">
                                            <Border.Background>
                                                <LinearGradientBrush
                                                    StartPoint="0,0"
                                                    EndPoint="1,1">
                                                    <LinearGradientBrush.GradientStops>
                                                        <GradientStop
                                                            Color="#FFFFFFFF"
                                                            Offset="0.2" />
                                                        <GradientStop
                                                            Color="#FFC0B7A6"
                                                            Offset="1" />
                                                    </LinearGradientBrush.GradientStops>
                                                </LinearGradientBrush>
                                            </Border.Background>
                                            <Path
                                                Data="M0,2L0,3 2,3 2,5 3,5 3,3 5,3 5,2 3,2 3,0 2,0 2,2z"
                                                Fill="#FF000000"
                                                Name="ExpandPath"
                                                Margin="1,1,1,1" />
                                        </Border>
                                    </Border>
                                    <ControlTemplate.Triggers>
                                        <Trigger
                                            Property="ToggleButton.IsChecked">
                                            <Setter
                                                Property="Path.Data"
                                                TargetName="ExpandPath">
                                                <Setter.Value>
                                                    <StreamGeometry>M0,2L0,3 5,3 5,2z</StreamGeometry>
                                                </Setter.Value>
                                            </Setter>
                                            <Trigger.Value>
                                                <s:Boolean>True</s:Boolean>
                                            </Trigger.Value>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ToggleButton.Style>
            </ToggleButton>
            <Border
                BorderThickness="{TemplateBinding Border.BorderThickness}"
                Padding="{TemplateBinding Control.Padding}"
                BorderBrush="{TemplateBinding Border.BorderBrush}"
                Background="{TemplateBinding Panel.Background}"
                Name="Bd"
                SnapsToDevicePixels="True"
                Grid.Column="1">
                <ContentPresenter
                    Content="{TemplateBinding HeaderedContentControl.Header}"
                    ContentTemplate="{TemplateBinding HeaderedContentControl.HeaderTemplate}"
                    ContentStringFormat="{TemplateBinding HeaderedItemsControl.HeaderStringFormat}"
                    ContentSource="Header"
                    Name="PART_Header"
                    HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}"
                    SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
            </Border>
            <ItemsPresenter
                Name="ItemsHost"
                Grid.Column="1"
                Grid.Row="1"
                Grid.ColumnSpan="2" />
        </Grid>
        <ControlTemplate.Triggers>
            <Trigger
                Property="TreeViewItem.IsExpanded">
                <Setter
                    Property="UIElement.Visibility"
                    TargetName="ItemsHost">
                    <Setter.Value>
                        <x:Static
                            Member="Visibility.Collapsed" />
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>False</s:Boolean>
                </Trigger.Value>
            </Trigger>
            <Trigger
                Property="ItemsControl.HasItems">
                <Setter
                    Property="UIElement.Visibility"
                    TargetName="Expander">
                    <Setter.Value>
                        <x:Static
                            Member="Visibility.Hidden" />
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>False</s:Boolean>
                </Trigger.Value>
            </Trigger>
            <Trigger
                Property="TreeViewItem.IsSelected">
                <Setter
                    Property="Panel.Background"
                    TargetName="Bd">
                    <Setter.Value>
                        <DynamicResource
                            ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
                    </Setter.Value>
                </Setter>
                <Setter
                    Property="TextElement.Foreground">
                    <Setter.Value>
                        <DynamicResource
                            ResourceKey="{x:Static SystemColors.HighlightTextBrushKey}" />
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>True</s:Boolean>
                </Trigger.Value>
            </Trigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition
                        Property="TreeViewItem.IsSelected">
                        <Condition.Value>
                            <s:Boolean>True</s:Boolean>
                        </Condition.Value>
                    </Condition>
                    <Condition
                        Property="Selector.IsSelectionActive">
                        <Condition.Value>
                            <s:Boolean>False</s:Boolean>
                        </Condition.Value>
                    </Condition>
                </MultiTrigger.Conditions>
                <Setter
                    Property="Panel.Background"
                    TargetName="Bd">
                    <Setter.Value>
                        <DynamicResource
                            ResourceKey="{x:Static SystemColors.ControlBrushKey}" />
                    </Setter.Value>
                </Setter>
                <Setter
                    Property="TextElement.Foreground">
                    <Setter.Value>
                        <DynamicResource
                            ResourceKey="{x:Static SystemColors.ControlTextBrushKey}" />
                    </Setter.Value>
                </Setter>
            </MultiTrigger>
            <Trigger
                Property="UIElement.IsEnabled">
                <Setter
                    Property="TextElement.Foreground">
                    <Setter.Value>
                        <DynamicResource
                            ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>False</s:Boolean>
                </Trigger.Value>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
