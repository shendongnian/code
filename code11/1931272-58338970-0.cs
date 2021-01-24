    <DataGrid x:Name="GridData" ItemsSource="{Binding MarketPriceGrid}">
      <DataGrid.ContextMenu>
        <ContextMenu>
          <MenuItem Header="OHLC Chart" Command={Binding ChartClickCommand}/>
         </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
  
    
