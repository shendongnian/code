        <CollectionViewSource x:Key="OSGroups">
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="os"/>
                <PropertyGroupDescription PropertyName="subGroup"/>
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
        <Style x:Key="GroupHeaderStyle" TargetType="{x:Type GroupItem}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type GroupItem}">
                        <Expander IsExpanded="True">
                            <Expander.Style>
                                <Style TargetType="{x:Type Expander}">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding IsBottomLevel}" Value="True">
                                            <Setter Property="Margin" Value="20,0,0,0" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Expander.Style>
                            <Expander.Header>
                                <TextBlock Text="{Binding Name}"/>
                            </Expander.Header>
                            <ItemsPresenter Margin="-10,0,0,0" />
                        </Expander>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
