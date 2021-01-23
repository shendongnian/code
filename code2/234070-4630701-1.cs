    <Window.Resources>
        <Style x:Key="HideWithoutDataContext">
            <Setter Property="UIElement.Visibility" Value="Visible" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding}" Value="{x:Null}">
                    <Setter Property="UIElement.Visibility" Value="Collapsed" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <TabControl>
        <TabItem Header="Start Page">
           ...
        </TabItem>
        <TabItem Header="Editor"
                 DataContext="{Binding Editor}"
                 Style="{DynamicResource HideWithoutDataContext}"/>
        <TabItem Header="Diagram"
                 DataContext="{Binding Diagram}"
                 Style="{DynamicResource HideWithoutDataContext}"/>
    </TabControl>
