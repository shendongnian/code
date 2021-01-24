    <ListView Name="lvSelectStudy" Tag="{Binding DataContext, RelativeSource={RelativeSource Self}}">
        <ListView.Resources>
            <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource {RelativeSource Self}}">                                
                <MenuItem Header="Lock" Command="{Binding LockCommand}"/>
            </ContextMenu>
        </ListView.Resources>
        ...
    </ListView>
