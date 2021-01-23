    <DataGrid x:Class="UICCNET.BaseControls.UserControls.BaseDataGrid"
             Tag="{Binding RelativeSource={RelativeSource Self}, Path=Columns}">
    <DataGrid.ContextMenu>
        <ContextMenu Tag="{Binding RelativeSource={RelativeSource Self},Path=PlacementTarget.Tag}">
            <MenuItem Header="Колонки">
            <MenuItem  >              
                <MenuItem.Template>
                    <ControlTemplate>
                            <ListBox  Name="MyComboBox"  ItemsSource="{Binding RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}},Path=Tag}">
                                <ListBox.ItemTemplate>
                                    <DataTemplate>
                                        <CheckBox IsChecked="{Binding Path=Visibility, Mode=TwoWay, Converter={StaticResource BooleanToVisibilityConverter1}}" Content="{Binding Path=Header}"></CheckBox>
                                    </DataTemplate>
                                </ListBox.ItemTemplate>
                            </ListBox>
                        </ControlTemplate>
                </MenuItem.Template>
                     </MenuItem>
            </MenuItem>
            <MenuItem Header="Друк"></MenuItem>
        </ContextMenu>
    </DataGrid.ContextMenu>
