    <DataTemplate>
        <Grid Tag="{Binding Decimals, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}}">
            <Grid.ToolTip>
                <ToolTip>
                    <StackPanel>
                        <TextBlock Text="{Binding Description}"/>
                        <TextBlock>
                            <TextBlock.Text>
                                <MultiBinding Converter="{cv_ToString:FromDecimal_MVConverter}">
                                    <Binding Path="Value"/>
                                    <Binding Path="PlacementTarget.Tag" RelativeSource="{RelativeSource FindAncestor, AncestorType=ToolTip}"/>
                                </MultiBinding>
                            </TextBlock.Text>
                        </TextBlock>
                    </StackPanel>
                </ToolTip>
            </Grid.ToolTip>
            ...
        </Grid>
    </DataTemplate>
