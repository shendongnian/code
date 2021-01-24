    <TabControl ...>
        <TabControl.Style>
            <Style TargetType="TabControl">
                <Style.Triggers>
                    <Trigger Property="HasItems" Value="False">
                        <Setter Property="Visibility" Value="Collapsed" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TabControl.Style>
        ...
    </TabControl>
