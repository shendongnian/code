    <Application.Resources>
        <local:ImgToDisplayConverter x:Key="ImgToDisplayConverter"/>
        <local:ImgPressedToDisplayConverter x:Key="ImgPressedToDisplayConverter"/>
        <Style TargetType="Image" x:Key="PressedButtonImageStyle">
            <Setter Property="Source">
                <Setter.Value>
                    <MultiBinding Converter="{StaticResource ImgToDisplayConverter}">
                        <Binding Path="Tag" RelativeSource="{RelativeSource AncestorType=Button}"/>
                    </MultiBinding>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsPressed, RelativeSource={RelativeSource AncestorType=Button}}" Value="true">
                    <Setter Property="Source">
                        <Setter.Value>
                            <MultiBinding Converter="{StaticResource ImgPressedToDisplayConverter}">
                                <Binding Path="Tag" RelativeSource="{RelativeSource AncestorType=Button}"/>
                            </MultiBinding>
                        </Setter.Value>
                    </Setter>
                </DataTrigger>
            </Style.Triggers>
        </Style>
        
    </Application.Resources>
