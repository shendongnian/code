    <Style TargetType="Image">
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding IsMouseOver, RelativeSource={RelativeSource Self}}" Value="True" />
                    <Condition Binding="{Binding IMG, Converter={StaticResource IsImageNullConverter}}" Value="False" />
                </MultiDataTrigger.Conditions>
                <Setter Property="ToolTip">
                    <Setter.Value>
                        <!-- Your ToolTip here -->
                    </Setter.Value>
                </Setter>
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
