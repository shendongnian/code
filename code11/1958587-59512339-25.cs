    <DataGrid x:Name="Tasks">
      <DataGrid.Columns>
        <DataGridTextColumn Header="Column1"
                            Binding="{Binding C1}" />
        <DataGridTextColumn Header="Column2"
                            Binding="{Binding C2}" />
      </DataGrid.Columns>
      <DataGrid.CellStyle>
        <Style TargetType="DataGridCell">
          <Setter Property="Foreground">
            <Setter.Value>
              <MultiBinding>
                <MultiBinding.Converter>
                  <CellForegroundMultiValueConverter />
                </MultiBinding.Converter>
                <Binding RelativeSource="{RelativeSource Self}"
                         Path="Column.Header"/>
                <Binding />
                <Binding Path="HasChanges" />
              </MultiBinding>
            </Setter.Value>
          </Setter>
        </Style>
      </DataGrid.CellStyle>
    </DataGrid>
