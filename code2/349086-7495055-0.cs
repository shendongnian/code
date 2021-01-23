    <UserControl x:Class="MyNamespace.MyUserControl"
                 ...
                 Style="{DynamicResource ResourceKey=MyUserControlStyle}">
        <UserControl.Resources>
            ...
            <Style x:Key="MyUserControlStyle" TargetType="{x:Type UserControl}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type UserControl}">
                            <Border BorderBrush="{Binding Path=DP1}">
                                ...
                                <ContentPresenter ... Content="{TemplateBinding Content}"/>
                                ...
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </UserControl.Resources>
    </UserControl>
