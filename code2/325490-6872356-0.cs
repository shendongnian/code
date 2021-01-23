    <Style TargetType="{x:Type TextBox}">
                <Setter Property="ToolTip" Value="{Binding RelativeSource={x:Static RelativeSource.Self}, Path=(Validation.Errors)[0].ErrorContent}"></Setter>
                            <Style.Triggers>
                                        <Trigger Property="IsVisible" Value="True">
                        <Setter Property="Validation.ErrorTemplate">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Border BorderBrush="Red" BorderThickness="1" >
                                        <AdornedElementPlaceholder/>
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
