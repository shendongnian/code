    <ContextMenu x:Key="BookItemContextMenu" 
                 Style="{StaticResource ContextMenuStyle1}">
        <MenuItem Command="{Binding Parent.PlacementTarget.Tag.DataContext.DoSomethingWithBookCommand,
                            RelativeSource={RelativeSource Mode=FindAncestor,
                            AncestorType=ContextMenu}}"
                  CommandParameter="{Binding}"
                  Header="Do Something With Book" />
        </MenuItem>>
    </ContextMenu>
    ...
    <ListView.ItemContainerStyle>
        <Style TargetType="{x:Type ListBoxItem}">
            <Setter Property="ContextMenu" Value="{StaticResource BookItemContextMenu}" />
            <Setter Property="Tag" Value="{Binding ElementName=thisUserControl}" />
        </Style>
    </ListView.ItemContainerStyle>
