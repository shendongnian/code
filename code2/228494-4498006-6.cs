    <TreeView ItemsSource="{Binding Projects}">
        <TreeView.ItemContainerStyle>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="AttachedBehaviors:MouseDoubleClickBehavior.MouseDoubleClick"
                        Value="{Binding YourCommand}"/>
            </Style>
        </TreeView.ItemContainerStyle>
    </TreeView>
