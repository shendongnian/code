    <UserControl.Resources>
        <local:TrimmedTextBlockVisibilityConverter x:Key="trimmedVisibilityConverter" />
    </UserControl.Resources>
    
    ....
    
    <TextBlock TextTrimming="CharacterEllipsis" Text="{Binding SomeTextProperty}">
        <TextBlock.ToolTip>
            <ToolTip Visibility="{Binding RelativeSource={RelativeSource Self}, Path=PlacementTarget, Converter={StaticResource trimmedVisibilityConverter}}">
                <ToolTip.Content>
                    <TextBlock Text="{Binding SomeTextProperty}"/>
                </ToolTip.Content>
            </ToolTip>
        </TextBlock.ToolTip>
    </TextBlock>
