        <Style x:Key="myStyle" TargetType="ListBoxItem" >
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListBoxItem}">
                        <Border Background="{TemplateBinding Background}">
                            <Border Background="Red"  Margin="10">
                                <ContentControl Content="{Binding}" />
                            </Border>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Background" Value="Black" />
                            </Trigger>
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property="Background" Value="Red" />
                            </Trigger>
                            <Trigger Property="IsFocused" Value="True">
                                <Setter Property="Background" Value="Orange" />
                            </Trigger>
                        </ControlTemplate.Triggers >
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
