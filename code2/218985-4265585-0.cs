                <DataGrid.ContextMenu>
                    <ContextMenu DataContext="{Binding SelectedItem, ElementName=DataGrid1}">
                        <MenuItem Header="Grant Access"
                                  IsEnabled="{Binding Connectable}" />
                    </ContextMenu>
                </DataGrid.ContextMenu>
