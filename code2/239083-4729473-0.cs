    <Grid>
    	<Controls:DataGrid Name="MenuDetailGrid" AutoGenerateColumns="False" ItemsSource="{Binding Terminals}">
    		<Controls:DataGrid.Columns>
    			<Controls:DataGridTemplateColumn Header="SomeHeader">
    				<Controls:DataGridTemplateColumn.CellTemplate>
    					<DataTemplate>
    						<TextBlock Text="{Binding TTYPE_NAME}" />
    					</DataTemplate>
    				</Controls:DataGridTemplateColumn.CellTemplate>
    				<Controls:DataGridTemplateColumn.CellEditingTemplate>
    					<DataTemplate>
    						<ComboBox DisplayMemberPath="TTYPE_NAME"
    							SelectedValuePath="TERMINAL_TYPE_ID"
    							SelectedValue="{Binding TERMINAL_TYPE_ID}"
    							ItemsSource="{Binding DataContext.TerminalTypes,RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Controls:DataGrid}}" />
    					</DataTemplate>
    				</Controls:DataGridTemplateColumn.CellEditingTemplate>
    			</Controls:DataGridTemplateColumn>
    		</Controls:DataGrid.Columns>
    	</Controls:DataGrid>
    </Grid>
