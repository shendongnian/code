    <GridViewColumn Header="Status">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding StateItem.HasError}" Value="True">
                                    <Setter Property="Content">
                                        <Setter.Value>
                                            <!-- Possibly create another contentcontrol which diffentiates between errors -->
                                            <TextBlock Text="{Binding StateItem.Error}"
                                                        Foreground="Red"/>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                                
                                <DataTrigger Binding="{Binding StateItem.HasError}" Value="False">
                                    <Setter Property="Content">
                                        <Setter.Value>
                                            <Image Source="Images/Default.ico"/>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
