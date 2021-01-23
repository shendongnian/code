    <Window x:Class="Window1" ... x:Name="myWindow">
    ...
        <Grid Tag="{Binding ElementName=myWindow}">
            <Grid.ContextMenu>
                <ContextMenu>
                    <MenuItem Command="{Binding PlacementTarget.Tag.DataContext.MyCommand, 
                                                RelativeSource={RelativeSource Mode=FindAncestor,                                                                                         
                                                                               AncestorType=ContextMenu}}"
                              Header="Test" />
                </ContextMenu>
            </Grid.ContextMenu>
        </Grid>
    </Window>
