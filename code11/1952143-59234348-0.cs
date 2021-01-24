        <TabControl Name="MainTabControl" Background="Red">
            <TabControl.Style>
                <Style TargetType="TabControl">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ItemsSource.Count, RelativeSource={RelativeSource Self}}" Value="0">
                            <Setter Property="Visibility" Value="Collapsed" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TabControl.Style>
            <TabControl.ItemTemplate>
                <!-- and so on -->
