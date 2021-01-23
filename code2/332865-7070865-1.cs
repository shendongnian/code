    <local:SolidColorBrushToGradientConverter x:Key="SolidColorBrushToGradientConverter" />
            
    <Style x:Key="GoogleMiddleButton" TargetType="{x:Type Button}">
        <Setter Property="Background" Value="#F5F5F5" />
        <Setter Property="Foreground" Value="#666666"/>
        <Setter Property="FontFamily" Value="Arial"/>
        <Setter Property="FontSize" Value="13"/>
        <Setter Property="FontWeight" Value="Bold"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border 
                        Name="dropShadowBorder"                        
                        BorderThickness="0,0,0,1"                        
                        CornerRadius="1"
                        >
                        <Border.BorderBrush>
                            <SolidColorBrush Color="#00000000"/>
                        </Border.BorderBrush>
                        <Border Name="border"                     
                                BorderThickness="{TemplateBinding BorderThickness}"                    
                                Padding="{TemplateBinding Padding}"                     
                                CornerRadius="0"                     
                                Background="{Binding Path=Background,Mode=OneWay,RelativeSource={RelativeSource Mode=TemplatedParent}, Converter={StaticResource SolidColorBrushToGradientConverter}, ConverterParameter=0.95}"
                                >
                            <Border.BorderBrush>
                                <SolidColorBrush Color="#D8D8D8"/>
                            </Border.BorderBrush>
                            <ContentPresenter 
                                HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"                                   
                                VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                />
                        </Border>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="BorderBrush" TargetName="border">
                                <Setter.Value>
                                    <SolidColorBrush Color="#939393"/>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="BorderBrush" TargetName="dropShadowBorder">
                                <Setter.Value>
                                    <SolidColorBrush Color="#EBEBEB"/>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                        <Trigger Property="IsPressed" Value="True">
                            <Setter Property="Background" Value="#4A8FF7" />
                            <Setter Property="Foreground" Value="#F5F5F5" />
                            <Setter Property="BorderBrush" TargetName="border">
                                <Setter.Value>
                                    <SolidColorBrush Color="#5185D8"/>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
