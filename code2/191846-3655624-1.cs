    <TabControl.Resources>
        <Style TargetType="{x:Type TabItem}">
            <Setter Property="HeaderTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <ContentPresenter>
                            <ContentPresenter.Content>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{TemplateBinding Content}"/>
                                    <TextBox Text="{TemplateBinding Content}"/>
                                </StackPanel>
                            </ContentPresenter.Content>
                        </ContentPresenter>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </TabControl.Resources>
