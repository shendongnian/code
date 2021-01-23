    <TabItem Header="TabItem">
        <TabItem.Style>
            <Style TargetType="TabItem">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=Header, RelativeSource={RelativeSource Self}, Converter={StaticResource HasAsteriskConverter}}" Value="True">
                        <Setter Property="Foreground" Value="Blue" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </TabItem.Style>
	<Grid />
    </TabItem>
