xml
            <!-- DataTemplate for Arrays -->
            <DataTemplate x:Key="ArrayDataTemplate">
                <DataGridCell Content="{Binding Path=Value, Mode=OneWay}" >
                    <DataGridCell.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="View / Edit..." />
                        </ContextMenu>
                    </DataGridCell.ContextMenu>
                </DataGridCell>
            </DataTemplate>
Any DataGridTemplateColumn a DataTemplate is applied to already contains DataGridCells in every row. 
So when I'm putting a DataGridCell inside the DataTemplate, I'm actually putting a DataGridCell inside the existing DataGridCell. This causes the problems when right clicking the cell. The ContextMenu is actually irrelevant, the problem occurs regardless.
This can be fixed by using another type of Container in the DataTemplate, for example like this:
xml
            <!-- DataTemplate for Arrays -->
            <DataTemplate x:Key="ArrayDataTemplate">
                <TextBox Text="{Binding Path=Value, Mode=OneWay}" >
                    <TextBox.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="View / Edit..." Click="menuItem_Click" />
                        </ContextMenu>
                    </TextBox.ContextMenu>
                </TextBox>
            </DataTemplate>
