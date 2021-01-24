    <Window>
      <Window.DataContext>
        <ViewModel />
      </Window.DataContext>
    
      <DataGrid ItemsSource="{Binding GridSource}" 
                AutoGeneratingColumn="DataGrid_OnAutoGeneratingColumn" 
                IsReadOnly="True">
        <DataGrid.Resources>
          <DataRowViewToCellDataConverter x:Key="DataRowViewToCellDataConverter" />
          <RowDataToRowNumberConverter x:Key="RowDataToRowNumberConverter" />
        </DataGrid.Resources>
        <DataGrid.CellStyle>
          <Style TargetType="DataGridCell">
            <Setter Property="Template">
              <Setter.Value>
                <ControlTemplate TargetType="DataGridCell">
    
                  <Button>
                    <Button.Content>
                      <MultiBinding Converter="{StaticResource DataRowViewToCellDataConverter }">
                        <Binding RelativeSource="{RelativeSource TemplatedParent}" 
                                 Path="DataContext" />
                        <Binding RelativeSource="{RelativeSource TemplatedParent}"
                                 Path="TabIndex" />
                      </MultiBinding>
                    </Button.Content>
                  </Button>
                </ControlTemplate>
              </Setter.Value>
            </Setter>
          </Style>
        </DataGrid.CellStyle>
    
        <DataGrid.RowHeaderStyle>
          <Style TargetType="{x:Type DataGridRowHeader}">
            <Setter Property="Content">
              <Setter.Value>
                <MultiBinding Converter="{StaticResource RowDataToRowNumberConverter}">
                  <Binding RelativeSource="{RelativeSource FindAncestor, AncestorType=DataGrid}" />
                  <Binding />
                </MultiBinding>
              </Setter.Value>
            </Setter>
          </Style>
        </DataGrid.RowHeaderStyle>
      </DataGrid>
    </Window>
