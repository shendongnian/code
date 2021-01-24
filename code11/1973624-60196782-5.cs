    <CartesianChart Margin="20"
                    Height="300"
                    Series="{Binding SeriesCollection}"
                    LegendLocation="Left">
      <CartesianChart.DataContext>
        <viewModels:ChartModel />
      </CartesianChart.DataContext>
      <CartesianChart.AxisX>
        <Axis Title="Timestamp"
              LabelFormatter="{Binding LabelFormatter}">
        </Axis>
      </CartesianChart.AxisX>
    </CartesianChart>
