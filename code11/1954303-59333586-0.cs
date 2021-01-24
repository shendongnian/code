xaml
<TabControl Grid.Row="2" Margin="0,3,0,0">
    <TabControl.Resources>
        <Style TargetType="{x:Type TabControl}">
            <Setter Property="SelectedIndex" Value="0"/>    <!-- This line -->
            <Style.Triggers>
                <DataTrigger
                    Binding="{Binding Path=GameMaster.Voices.Count, Mode=OneWay, Converter={StaticResource CountGreaterThanZeroConverter}}"
                    Value="False">
                    <Setter Property="SelectedIndex" Value="0" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TabControl.Resources>
        ...
</TabControl>
