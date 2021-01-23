    <GridViewColumn Header="Status">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsActive}" Value="True">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <StackPanel>
                                                    <ProgressBar Height="20"
                                                                 Value="{Binding Id}" Minimum="0" Maximum="10"/>
                                                </StackPanel>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
    
                                <!-- ... -->
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
