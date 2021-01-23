    <StackPanel>
                <ItemsControl ItemsSource="{Binding Path=Views}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <CheckBox IsChecked="{Binding Path=IsSelected}"></CheckBox>
                                <TextBlock Text="{Binding Path=Title}"></TextBlock>
                            </StackPanel>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
                <TabControl ItemsSource="{Binding Path=Views}">
                    <TabControl.ItemTemplate>
                        <DataTemplate>
                            <Grid>
                                <TextBlock Text="{Binding Path=Title}"></TextBlock>
                            </Grid>
                        </DataTemplate>
                    </TabControl.ItemTemplate>
                    <TabControl.Resources>
                        <Style TargetType="TabItem">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=IsSelected}" Value="False">
                                    <Setter Property="Visibility" Value="Collapsed"></Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TabControl.Resources>
                </TabControl>
            </StackPanel>
