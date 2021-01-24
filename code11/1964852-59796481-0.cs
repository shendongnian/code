        <Button Width="50" Height="50" Content="Hi" Click="ButtonBase_OnClick" >
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="Background" Value="LightGray"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            
                            <ControlTemplate TargetType="{x:Type Button}">
                                <Border Background="{TemplateBinding Background}">
                                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="LightGray"></Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
