    <ItemsControl ItemsSource="{Binding Path=MyItems}">
        <ItemsControl.Style>
            <Style TargetType="ItemsControl">
                    <Setter Property="ItemTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <Grid>
                                    <!--default template-->
                                </Grid>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                    <DataTrigger Binding="{Binding MyValue}" Value="1">
                        <Setter Property="ItemTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Grid>
                                        <TextBox/>
                                    </Grid>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding MyValue}" Value="2">
                        <Setter Property="ItemTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Grid>
                                        <CheckBox/>
                                    </Grid>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding MyValue}" Value="3">
                        <Setter Property="ItemTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Grid>
                                        <TextBox/>
                                    </Grid>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ItemsControl.Style>
    </ItemsControl>
