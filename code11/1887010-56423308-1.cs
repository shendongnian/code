    <ItemsControl ItemsSource="{Binding}">
        <ItemsControl.Template>
            <ControlTemplate TargetType="ItemsControl">
                <ScrollViewer VerticalScrollBarVisibility="Visible">
                    <ItemsPresenter />
                </ScrollViewer>
            </ControlTemplate>
        </ItemsControl.Template>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid Columns="5" VerticalAlignment="Top"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button ... />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsVisible}" Value="False">
                        <Setter Property="Visibility" Value="Collapsed"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
