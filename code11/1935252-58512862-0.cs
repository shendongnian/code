     <ListBox.Template>
                <ControlTemplate>
                    <ScrollViewer x:Name="ScrollViewer1" ScrollChanged="HandleScrollChanged"
                                  CanContentScroll="True" 
                                  ScrollViewer.VerticalScrollBarVisibility="Auto"
                                  ScrollViewer.HorizontalScrollBarVisibility="Disabled">
                        <ItemsPresenter />
                    </ScrollViewer>
                </ControlTemplate>
            </ListBox.Template>
    <Grid x:Name="GridRoot" Width="250" Height="460" Background="Red" >
                            <Grid.Style>
                                <Style TargetType="{x:Type Grid}">
                                    <Setter Property="Visibility" Value="Collapsed"/>
                                    <Setter Property="Opacity" Value="0"/>
                                    <Style.Triggers>
                                        <Trigger Property="Visibility" Value="Visible">
                                            <Trigger.EnterActions>
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0" To="1" Duration="0:0:0.8" />
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </Trigger.EnterActions>
                                        </Trigger>
                                    </Style.Triggers>
                                </Style>
                            </Grid.Style>
                        </Grid>
