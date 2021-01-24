    <Button Name="BTN_OpenContext" Content="CLICK TO OPEN"
            Tag="{Binding ElementName=DG_Data}">
        <Button.ContextMenu>
            <ContextMenu Name="CM_ContextMenu">
                <MenuItem Header="{Binding Path=PlacementTarget.Tag.Columns.Count, 
                        RelativeSource={RelativeSource AncestorType=ContextMenu}, FallbackValue=BindingFailed}" />
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
