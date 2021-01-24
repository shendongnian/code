    <Grid x:Name="StudentGrid" DataContext="{Binding StudentViewModel}">
       <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Students}">
          <DataGrid.Columns>
             <DataGridTextColumn Binding="{Binding Name}" IsReadOnly="True" Width="*" />
             <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                   <DataTemplate>
                      <Button Command="{Binding Path=DataContext.EditOrCreateStudentCommand, ElementName=StudentGrid}"/>
                   </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
             </DataGridTemplateColumn>
          </DataGrid.Columns>
       </DataGrid>
    </Grid>
