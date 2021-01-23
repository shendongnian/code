    <Style TargetType="local:SomeControl">
        <Style.Setters>
            <Setter Property="Control.Template">
                <Setter.Value>
                    <ControlTemplate TargetType="local:SomeControl">
                        <StackPanel>
                            <TextBlock Text="DefaultTemplate"></TextBlock>
                        </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style.Setters>
        <Style.Triggers>
            <Trigger Property="IsAdvanced" Value="True">
                <Trigger.Setters>
                    <Setter Property="Control.Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="local:SomeControl">
                                <TextBlock Text="Advanced Template"></TextBlock>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Trigger.Setters>
            </Trigger>
        </Style.Triggers>
    </Style>
