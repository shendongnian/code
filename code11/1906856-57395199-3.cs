    <ListBox.ContextMenu>
        <ContextMenu ItemsSource="{Binding CadModelContextMenu}"
            ItemTemplateSelector="{StaticResource PanelContextMenuItemDataTemplateSelector}"
            UsesItemContainerTemplate="True">
            <ContextMenu.Resources>
                <ResourceDictionary>
                    <Image x:Key="menuIcon" x:Shared="false"
                        Source="{Binding Path=Icon}" Height="16px" Width="16px"/>
                </ResourceDictionary>
            </ContextMenu.Resources>
            <ContextMenu.ItemContainerStyle>
                <Style TargetType="{x:Type MenuItem}">
                    <Setter Property="Icon" Value="{StaticResource menuIcon}"/>
                    <Setter Property="Command" Value="{Binding Command}"/>
                </Style>
            </ContextMenu.ItemContainerStyle>
        </ContextMenu>
    </ListBox.ContextMenu>
