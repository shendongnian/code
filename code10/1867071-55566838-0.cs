     <TextBox>
            <TextBox.Style>
                <Style TargetType="TextBox">
                    <Style.Triggers>
                        <Trigger Property="Validation.HasError" Value="true">
                            <Setter Property="ToolTip" Value="{Binding RelativeSource={RelativeSource Self},
                        Path=(Validation.Errors).[0].ErrorContent}" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
