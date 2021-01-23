    var xaml2 = @"<DockPanel xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                             xmlns:s=""clr-namespace:System;assembly=mscorlib"" 
                             xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                    <DockPanel.Resources>
                        <Style TargetType=""TextBox"" x:Key=""{x:Type TextBox}"">
                            <Style.Triggers>
                                <Trigger Property=""TextEditor.IsReadOnly"">
                                    <Setter Property=""Panel.Background"">
                                        <Setter.Value>
                                            <SolidColorBrush>#FFEEEEEE</SolidColorBrush>
                                        </Setter.Value>
                                    </Setter>
                                    <Trigger.Value>
                                        <s:Boolean>True</s:Boolean>
                                    </Trigger.Value>
                                </Trigger>
                            </Style.Triggers>
                            <Style.Resources>
                                <ResourceDictionary />
                            </Style.Resources>
                        </Style>
                    </DockPanel.Resources>
                    <TextBox IsReadOnly=""True"" xml:space=""preserve"" />
                </DockPanel>";
