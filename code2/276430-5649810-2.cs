    <sdk:DataGrid ItemsSource="{Binding MyList}" RowStyle="{StaticResource Style1}" AutoGenerateColumns="False">
        		<sdk:DataGrid.Columns>
                    <sdk:DataGridTemplateColumn>
                        <sdk:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding SomeEntity, StringFormat=c}"  />
                            </DataTemplate>
                        </sdk:DataGridTemplateColumn.CellTemplate>
                    </sdk:DataGridTemplateColumn>
                    <sdk:DataGridTextColumn Binding="{Binding PropertyToBeWatched}" Header="Property1"/>
        		</sdk:DataGrid.Columns>
        	</sdk:DataGrid>
