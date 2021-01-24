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
            <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self}, Path=Content.Text}"
                         Value="Error Predicate Text" />
              <Setter Property="Foreground" Value="Red" />
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </DataGrid.CellStyle>
    </DataGrid>
