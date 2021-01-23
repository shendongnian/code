      <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Insert"
                          Command="{Binding DataContext.InsertQuery, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"/>
                <MenuItem Header="Delete" 
                          Command="{Binding DataContext.DeleteQuery, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"/>
            </ContextMenu>
      </DataGrid.ContextMenu>
