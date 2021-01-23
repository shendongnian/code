    <sdk:DataGrid ItemsSource="{Binding MyList}" AutoGenerateColumns="False">
        		<sdk:DataGrid.Columns>
                    <sdk:DataGridTemplateColumn>
                        <sdk:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding SomeProperty, StringFormat=c}"  />
                            </DataTemplate>
                        </sdk:DataGridTemplateColumn.CellTemplate>
                    </sdk:DataGridTemplateColumn>
        		</sdk:DataGrid.Columns>
        	</sdk:DataGrid>
