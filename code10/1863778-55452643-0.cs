    <ItemsControl AlternationCount="{Binding RelativeSource={RelativeSource Self}, Path=Items.Count}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Horizontal" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock>
                    <Run Text="{Binding Path=., Mode=OneWay}" /><Run x:Name="delimiter" Text=";    "/>
                </TextBlock>
                <DataTemplate.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                        <Setter Property="Text" TargetName="delimiter" Value=""/>
                    </Trigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
