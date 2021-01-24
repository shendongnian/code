    <Style TargetType="{x:Type TabItem}">
        <Setter Property="HeaderTemplate">
            <Setter.Value>
                <DataTemplate>
                    <ContentPresenter TextElement.FontSize="30" 
                                      TextElement.Foreground="Blue" 
                                      Content="{Binding Path=Header, RelativeSource={RelativeSource AncestorType=TabItem}}"/>
                </DataTemplate>
            </Setter.Value>
        </Setter>
    </Style>
<!---->
    <TabItem>
        <TabItem.Header>
            <TextBlock Text="Tab No. 2" FontSize="20" Foreground="Black"></TextBlock>
        </TabItem.Header>
        <TextBlock>Hello World</TextBlock>
    </TabItem>
    <TabItem Header="Tab No. 2">
        <TextBlock FontSize="24">We Have Tearable Tabs!</TextBlock>
    </TabItem>
