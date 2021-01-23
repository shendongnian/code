    &lt;UserControl.Resources>
        &lt;Converters:AllValuesEqualToBooleanConverter x:Key="IsCheckedVisibilityConverter" EqualValue="True" NotEqualValue="False" />
    &lt;/UserControl.Resources>
    &lt;Grid>
        &lt;Grid.ContextMenu>
            &lt;ContextMenu ItemsSource="{Binding MenuData, Mode=OneWay}">
                &lt;ContextMenu.ItemContainerStyle>
                    &lt;Style TargetType="MenuItem" >
                        &lt;Setter Property="Header" Value="{Binding Item1}" />
                        &lt;Setter Property="IsCheckable" Value="True" />
                        &lt;Setter Property="IsChecked">
                            &lt;Setter.Value>
                                &lt;MultiBinding Converter="{StaticResource IsCheckedVisibilityConverter}" Mode="OneWay">
                                    &lt;Binding Path="DataContext.Selected" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type Views:Type3}}"  />
                                    &lt;Binding Path="Item2" />
                                &lt;/MultiBinding>
                            &lt;/Setter.Value>
                        &lt;/Setter>
                        &lt;Setter Property="Command" Value="{Binding Path=DataContext.ContextMenuClickedCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Views:Type3}}}" />
                        &lt;Setter Property="CommandParameter" Value="{Binding .}" />
                    &lt;/Style>
                &lt;/ContextMenu.ItemContainerStyle>
            &lt;/ContextMenu>
        &lt;/Grid.ContextMenu>
        &lt;Grid.RowDefinitions>&lt;RowDefinition Height="*" />&lt;/Grid.RowDefinitions>
        &lt;Grid.ColumnDefinitions>&lt;ColumnDefinition Width="*" />&lt;/Grid.ColumnDefinitions>
        &lt;TextBlock Grid.Row="0" Grid.Column="0" FontSize="30" Text="Right Click For Menu" />
    &lt;/Grid>
