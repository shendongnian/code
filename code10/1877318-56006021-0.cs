    <ControlTemplate TargetType="{x:Type ComboBoxItem}">
        <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
            <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Border>
        <ControlTemplate.Triggers>
            <Trigger Property="IsEnabled" Value="False">
                <Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
            </Trigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="False"/>
                    <Condition Property="IsMouseOver" Value="True"/>
                    <Condition Property="IsKeyboardFocused" Value="False"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewHover.Background}"/>
                <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewHover.Border}"/>
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="True"/>
                    <Condition Property="IsMouseOver" Value="False"/>
                    <Condition Property="IsKeyboardFocused" Value="True"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewSelected.Background}"/>
                <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewSelected.Border}"/>
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="True"/>
                    <Condition Property="IsMouseOver" Value="True"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewSelectedHover.Background}"/>
                <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewSelectedHover.Border}"/>
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="True"/>
                    <Condition Property="IsMouseOver" Value="False"/>
                    <Condition Property="IsKeyboardFocused" Value="False"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewSelectedNoFocus.Background}"/>
                <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewSelectedNoFocus.Border}"/>
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="False"/>
                    <Condition Property="IsMouseOver" Value="False"/>
                    <Condition Property="IsKeyboardFocused" Value="True"/>
                </MultiTrigger.Conditions>
                <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewFocus.Border}"/>
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="False"/>
                    <Condition Property="IsMouseOver" Value="True"/>
                    <Condition Property="IsKeyboardFocused" Value="True"/>
                </MultiTrigger.Conditions>
                <Setter Property="Background" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewHoverFocus.Background}"/>
                <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource ComboBoxItem.ItemsviewHoverFocus.Border}"/>
            </MultiTrigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
