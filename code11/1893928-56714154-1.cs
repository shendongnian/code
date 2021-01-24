       <Style x:Key="TreeViewItemFocusVisual">
            <Setter Property="Control.Template">
                <Setter.Value>
                    <ControlTemplate>
                        <Rectangle/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="ExpandCollapseToggleStyle" TargetType="{x:Type ToggleButton}">
            <Setter Property="Focusable" Value="False"/>
            <Setter Property="Width" Value="19"/>
            <Setter Property="Height" Value="13"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ToggleButton}">
                        <Border Width="19" Height="13" Background="Transparent">
                            <Border SnapsToDevicePixels="true" Width="10" Height="10">
                                <Polyline Points="0,0 5,5 10,0"
                                          x:Name="Triangle"
                                          Stroke="Black"/>
                            </Border>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter Property="Points" TargetName="Triangle" Value="0,10 5,5 0,0"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style TargetType="{x:Type TreeViewItem}">
            <Setter Property="Foreground" Value="Black"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="Padding" Value="1,0,0,0"/>
            <Setter Property="FocusVisualStyle" Value="{StaticResource TreeViewItemFocusVisual}"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type TreeViewItem}">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition MinWidth="19" Width="Auto"/>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto"/>
                                <RowDefinition/>
                            </Grid.RowDefinitions>
                            <ToggleButton x:Name="Expander"
                                          Style="{StaticResource ExpandCollapseToggleStyle}"
                                          ClickMode="Press"
                                          IsChecked="{Binding Path=IsExpanded,
                            RelativeSource={RelativeSource TemplatedParent}}"/>
                            <Border Grid.Column="0"
                                    Grid.ColumnSpan="2"
                                    x:Name="Bd"
                                    SnapsToDevicePixels="true"
                                    Background="{TemplateBinding Background}"
                                    BorderThickness="2,0,0,0"
                                    Padding="{TemplateBinding Padding}">
                            </Border>
                            <ContentPresenter x:Name="PART_Header"
                                              Grid.Column="1"
                              SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"
                              HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                              ContentSource="Header"/>
                            <ItemsPresenter x:Name="ItemsHost" Grid.Column="0" Grid.ColumnSpan="2" Grid.Row="1"/>
                        </Grid> <ControlTemplate.Triggers>
                            <Trigger Property="IsExpanded" Value="false">
                                <Setter Property="Visibility" TargetName="ItemsHost" Value="Collapsed"/>
                            </Trigger>
                            <Trigger Property="HasItems" Value="false">
                                <Setter Property="Visibility" TargetName="Expander" Value="Hidden"/>
                            </Trigger>
                            <Trigger Property="IsSelected" Value="true">
                                <Setter Property="BorderBrush" TargetName="Bd" Value="#ff42f46e"/>
                                <Setter Property="Background" TargetName="Bd">
                                    <Setter.Value>
                                        <SolidColorBrush Color="Gray" Opacity="0.3"/>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style TargetType="TreeView">
            <Setter Property="Background" Value="White"/>
        </Style>
and finally test it
        <TreeView Width="300">
            <TreeViewItem Header="Home"/>
            <TreeViewItem Header="Menu">
                <TreeViewItem Header="something1"/>
                <TreeViewItem Header="something2"/>
                <TreeViewItem Header="something3"/>
            </TreeViewItem>
            <TreeViewItem Header="Settings"/>
        </TreeView>
Screenshot of result
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/cfAr2.png
