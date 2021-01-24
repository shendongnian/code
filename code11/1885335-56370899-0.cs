    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="2*"></ColumnDefinition>
            <ColumnDefinition Width="8*"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <telerikChart:RadCartesianChart x:Name="chart" Grid.Column="1">
            <telerikChart:RadCartesianChart.HorizontalAxis>
                <telerikChart:CategoricalAxis />
            </telerikChart:RadCartesianChart.HorizontalAxis>
            <telerikChart:RadCartesianChart.VerticalAxis>
                <telerikChart:LinearAxis />
            </telerikChart:RadCartesianChart.VerticalAxis>
            <telerikChart:RadCartesianChart.SeriesProvider>
                <telerikChart:ChartSeriesProvider x:Name="provider">
                    <telerikChart:ChartSeriesProvider.SeriesDescriptors>
                        <telerikChart:CategoricalSeriesDescriptor ItemsSourcePath="GetData" ValuePath="Value" CategoryPath="Category" LegendTitlePath="LegendTitle">
                            <telerikChart:CategoricalSeriesDescriptor.Style>
                                <Style TargetType="telerikChart:BarSeries">
                                    <Setter Property="CombineMode" Value="Cluster" />
                                </Style>
                            </telerikChart:CategoricalSeriesDescriptor.Style>
                        </telerikChart:CategoricalSeriesDescriptor>
                    </telerikChart:ChartSeriesProvider.SeriesDescriptors>
                </telerikChart:ChartSeriesProvider>
            </telerikChart:RadCartesianChart.SeriesProvider>
        </telerikChart:RadCartesianChart>
        <ScrollViewer>
            <telerikPrimitives:RadLegendControl x:Name="LegendForChart" LegendProvider="{Binding ElementName=chart}">
                <telerikPrimitives:RadLegendControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <ItemsStackPanel Orientation="Vertical" />
                    </ItemsPanelTemplate>
                </telerikPrimitives:RadLegendControl.ItemsPanel>
            </telerikPrimitives:RadLegendControl>
        </ScrollViewer>
    </Grid>
