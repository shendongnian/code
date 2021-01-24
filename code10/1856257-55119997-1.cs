    <Window.Resources>
            <ContextMenu x:Key="ContextMenu1">
                <ContextMenu.Items>
                    <MenuItem Header="{Binding DataContext.Title,RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window} }"/>
                    <MenuItem Header="{Binding DataContext.Title,RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window}}" />
                    <MenuItem Header="{Binding DataContext.Title,RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window}}" />
                </ContextMenu.Items>
            </ContextMenu>
        </Window.Resources>
        <Grid>
            <DataGrid ItemsSource="{Binding VentingTypesCollection}">
                <DataGrid.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Setter Property="ContextMenu" Value="{StaticResource ContextMenu1}" />
                    </Style>
                </DataGrid.CellStyle>
            </DataGrid>
        </Grid>
