    <DataGrid x:Name="Tasks">
      <DataGrid.Columns>
        <DataGridTextColumn Header="Column1"
                            Binding="{Binding C1}" />
        <DataGridTextColumn Header="Column2"
                            Binding="{Binding C2}" />
      </DataGrid.Columns>
      <DataGrid.CellStyle>
        <Style TargetType="DataGridCell">
          <Style.Triggers>
            <MultiDataTrigger>
              <MultiDataTrigger.Conditions>
                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=Column.Header}"
                           Value="Column1" />
                <Condition Binding="{Binding C1}" Value="Error Predicate Text" />
              </MultiDataTrigger.Conditions>
              <Setter Property="Foreground" Value="Red" />
            </MultiDataTrigger>
          </Style.Triggers>
        </Style>
      </DataGrid.CellStyle>
    </DataGrid>
