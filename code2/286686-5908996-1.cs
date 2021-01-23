    <GridViewColumn Header="Status">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding StateItem.HasError}" Value="True">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <!-- Possibly create another contentcontrol which diffentiates between errors -->
                                            <DataTemplate>
                                                 <TextBlock Text="{Binding StateItem.Error}"
                                                            Foreground="Red"/>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                                
                                <DataTrigger Binding="{Binding StateItem.HasError}" Value="False">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <Image Source="Images/Default.ico"/>
                                            </DataTemplate>
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
