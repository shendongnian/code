    <ListView x:Name="myCheckBoxColumns" ScrollViewer.VerticalScrollBarVisibility="Auto" ItemsSource="{Binding}">
    	<ListView.View>
    		<GridView>
    			<GridViewColumn Width="250" Header="Some Header">
    				<GridViewColumn.CellTemplate>
    					<DataTemplate>
    						<CheckBox IsChecked="{Binding State}" Content="{Binding Caption}" />
    					</DataTemplate>
    				</GridViewColumn.CellTemplate>
    			</GridViewColumn>
    		</GridView>
    	</ListView.View>
    </ListView>
