    <ContextMenu>
        <MenuItem Header="Remove" Command="{Binding RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}}, 
                        Path=PlacementTarget.DataContext.ValidateAllCommand}">
        </MenuItem>
    </ContextMenu>
