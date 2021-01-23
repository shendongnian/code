    <ContextMenu ItemsSource="{Binding MyMenu}">
        <ContextMenu.Resources>
            <Style TargetType="{x:Type MenuItem}">
                <Setter Property="Template" 
                        Value="{StaticResource MyMenuItemTemplate}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding }" Value="{x:Null}">
                        <Setter Property="Template" 
                                Value="{StaticResource MySeparatorTemplate}" />
                    </DataTrigger>
                </Style.Resources>
            </Style>
        </ContextMenu.Resources>
    </ContextMenu>
