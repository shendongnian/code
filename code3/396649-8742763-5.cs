    <Style TargetType="{x:Type MenuItem}" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:s="clr-namespace:System;assembly=mscorlib">
        <Style.Triggers>
            <Trigger Property="MenuItem.Role">
                <Setter Property="Control.Padding">
                    <Setter.Value>
                        <Thickness>
                            7,2,8,3</Thickness>
                        </Setter.Value>
                    </Setter>
                <Setter Property="Control.Template">
                    <Setter.Value>
                        <DynamicResource ResourceKey="{ComponentResourceKey TypeInTargetAssembly=MenuItem, ResourceId=TopLevelHeaderTemplateKey}" />
                        </Setter.Value>
                    </Setter>
                <Trigger.Value>
                    <x:Static Member="MenuItemRole.TopLevelHeader" />
                    </Trigger.Value>
                </Trigger>
            <Trigger Property="MenuItem.Role">
                <Setter Property="Control.Padding">
                    <Setter.Value>
                        <Thickness>
                            7,2,8,3</Thickness>
                        </Setter.Value>
                    </Setter>
                <Setter Property="Control.Template">
                    <Setter.Value>
                        <DynamicResource ResourceKey="{ComponentResourceKey TypeInTargetAssembly=MenuItem, ResourceId=TopLevelItemTemplateKey}" />
                        </Setter.Value>
                    </Setter>
                <Trigger.Value>
                    <x:Static Member="MenuItemRole.TopLevelItem" />
                    </Trigger.Value>
                </Trigger>
            <Trigger Property="MenuItem.Role">
                <Setter Property="Control.Padding">
                    <Setter.Value>
                        <Thickness>
                            2,3,2,3</Thickness>
                        </Setter.Value>
                    </Setter>
                <Setter Property="Control.Template">
                    <Setter.Value>
                        <DynamicResource ResourceKey="{ComponentResourceKey TypeInTargetAssembly=MenuItem, ResourceId=SubmenuHeaderTemplateKey}" />
                        </Setter.Value>
                    </Setter>
                <Trigger.Value>
                    <x:Static Member="MenuItemRole.SubmenuHeader" />
                    </Trigger.Value>
                </Trigger>
            <Trigger Property="MenuItem.Role">
                <Setter Property="Control.Padding">
                    <Setter.Value>
                        <Thickness>
                            2,3,2,3</Thickness>
                        </Setter.Value>
                    </Setter>
                <Trigger.Value>
                    <x:Static Member="MenuItemRole.SubmenuItem" />
                    </Trigger.Value>
                </Trigger>
            </Style.Triggers>
        <Style.Resources>
            <ResourceDictionary />
            </Style.Resources>
        <Setter Property="Control.HorizontalContentAlignment">
            <Setter.Value>
                <Binding Path="HorizontalContentAlignment" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ItemsControl, AncestorLevel=1}" />
                </Setter.Value>
            </Setter>
        <Setter Property="Control.VerticalContentAlignment">
            <Setter.Value>
                <Binding Path="VerticalContentAlignment" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ItemsControl, AncestorLevel=1}" />
                </Setter.Value>
            </Setter>
        <Setter Property="Panel.Background">
            <Setter.Value>
                <SolidColorBrush>
                    #00FFFFFF</SolidColorBrush>
                </Setter.Value>
            </Setter>
        <Setter Property="ScrollViewer.PanningMode">
            <Setter.Value>
                <x:Static Member="PanningMode.Both" />
                </Setter.Value>
            </Setter>
        <Setter Property="Stylus.IsFlicksEnabled">
            <Setter.Value>
                <s:Boolean>
                    False</s:Boolean>
                </Setter.Value>
            </Setter>
        <Setter Property="Control.Template">
            <Setter.Value>
                <DynamicResource ResourceKey="{ComponentResourceKey TypeInTargetAssembly=MenuItem, ResourceId=SubmenuItemTemplateKey}" />
                </Setter.Value>
            </Setter>
        </Style>
