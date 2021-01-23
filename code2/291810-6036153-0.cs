    <GridViewColumn>
    
     <GridViewColumn.Header>
         <CheckBox/>
      </GridViewColumn.Header>
    
      <GridViewColumn.CellTemplate>
        <DataTemplate>
          <StackPanel Orientation="Horizontal">
             <CheckBox IsChecked="{Binding IsSelected}" />
          </StackPanel>
        </DataTemplate>
      </GridViewColumn.CellTemplate>
    </GridViewColumn>
