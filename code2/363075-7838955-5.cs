    <Window.Resources>
        <DataTemplate TargetType="{x:Type local:TabAViewModel}">
            <local:TabAView />
        </DataTemplate>
        <DataTemplate TargetType="{x:Type local:TabBViewModel}">
            <local:TabBView />
        </DataTemplate>
    </Window.Resources>
    <TabControl ItemsSource="{Binding TabItems}">
        <TabControl.ItemContainerStyle> 
            <Style TargetType="{x:Type TabItem}"> 
                <Setter Property="Header" Value="{Binding Header}" />
            </Style> 
        </TabControl.ItemContainerStyle>
    </TabControl>
