    <Grid>
        <Grid.Resources>
            <Style x:Key="MyItemContainerStyle" TargetType="{x:Type ListViewItem}">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
                <Setter Property="VerticalContentAlignment" Value="Stretch" />
            </Style>
        </Grid.Resources>
                
        <ListView 
            ItemContainerStyle="{DynamicResource MyItemContainerStyle}"
            ItemsSource="{x:Static Fonts.SystemFontFamilies}"
            x:Name="myListView"
            Width="Auto">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Name">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Border BorderBrush="#FF000000" BorderThickness="1,1,0,0" Margin="-6,-2,-6,-2">
                                    <StackPanel Margin="6,2,6,2">
                                        <TextBlock Text="{Binding Source}"/>
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Line Spacing">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                               <Border BorderBrush="#FF000000" BorderThickness="1,1,0,0" Margin="-6,-2,-6,-2">
                                    <StackPanel Margin="6,2,6,2">
                                        <TextBlock Text="{Binding LineSpacing}"/>
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Sample">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Border BorderBrush="#FF000000" BorderThickness="1,1,1,0" Margin="-6,-2,-6,-2">
                                    <StackPanel Margin="6,2,6,2">
                                        <TextBlock FontFamily="{Binding}" FontSize="20"
                                           Text="ABCDEFGabcdefg" />
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
