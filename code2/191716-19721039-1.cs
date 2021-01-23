    <UserControl.Resources>
        <Converters:AllValuesEqualToBooleanConverter x:Key="IsCheckedVisibilityConverter" EqualValue="True" NotEqualValue="False" />
    </UserControl.Resources>
    <Grid>
        <Grid.ContextMenu>
            <ContextMenu ItemsSource="{Binding MenuData, Mode=OneWay}">
                <ContextMenu.ItemContainerStyle>
                    <Style TargetType="MenuItem" >
                        <Setter Property="Header" Value="{Binding Item1}" />
                        <Setter Property="IsCheckable" Value="True" />
                        <Setter Property="IsChecked">
                            <Setter.Value>
                                <MultiBinding Converter="{StaticResource IsCheckedVisibilityConverter}" Mode="OneWay">
                                    <Binding Path="DataContext.Selected" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type Views:Type3}}"  />
                                    <Binding Path="Item2" />
                                </MultiBinding>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="Command" Value="{Binding Path=DataContext.ContextMenuClickedCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Views:Type3}}}" />
                        <Setter Property="CommandParameter" Value="{Binding .}" />
                    </Style>
                </ContextMenu.ItemContainerStyle>
            </ContextMenu>
        </Grid.ContextMenu>
        <Grid.RowDefinitions><RowDefinition Height="*" /></Grid.RowDefinitions>
        <Grid.ColumnDefinitions><ColumnDefinition Width="*" /></Grid.ColumnDefinitions>
        <TextBlock Grid.Row="0" Grid.Column="0" FontSize="30" Text="Right Click For Menu" />
    </Grid>
