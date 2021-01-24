    <Popup IsOpen="True">
        <StackPanel Background="White">
            <ItemsControl>
                <MenuItem Header="Open file..." />
                <MenuItem Header="Settings" />
                <!-- Nested items -->
                <MenuItem Header="Test">
                    <MenuItem Header="Nested Item" />
                    <MenuItem Header="Nested Item" />
                    <MenuItem Header="Nested Item" />
                    <MenuItem Header="Nested Item" />
                    <MenuItem Header="Nested Item" />
                    <MenuItem.Style>
                        <Style TargetType="MenuItem">
                            <Style.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter Property="IsSubmenuOpen" Value="True" />
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </MenuItem.Style>
                </MenuItem>
                <MenuItem Header="Exit" />
            </ItemsControl>
        </StackPanel>
    </Popup>
