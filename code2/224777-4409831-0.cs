        ...<ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Value.Name}"  Padding="5">
                                <TextBlock.Style>
                                    <Style>
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding Value.StartAnimation}" Value="True">
                                                <DataTrigger.EnterActions>
                                                    <BeginStoryboard>
                                                        <Storyboard
                                                            Storyboard.TargetProperty="FontSize"
                                                            Duration="0:0:0.5">
                                                            <DoubleAnimation From="10" To="30" AutoReverse="True" />
                                                        </Storyboard>
                                                    </BeginStoryboard>
                                                </DataTrigger.EnterActions>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </TextBlock.Style>
                            </TextBlock>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
    ...
