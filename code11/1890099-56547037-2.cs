    <Menu>
        <Menu.Resources>
            <Style x:Key="{x:Static MenuItem.SeparatorStyleKey}" TargetType="{x:Type Separator}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type Separator}">
                            <Border Background="{TemplateBinding Control.Background}"
                                    BorderBrush="{TemplateBinding Control.BorderBrush}"
                                    BorderThickness="{TemplateBinding Control.BorderThickness}" 
                                    Margin="0"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Menu.Resources>
        <Menu.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel />
            </ItemsPanelTemplate>
        </Menu.ItemsPanel>
        <MenuItem Header="Item1" />
        <Separator />
        <MenuItem Header="Item2" />
        <Separator />
    </Menu>
