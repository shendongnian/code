	  <DataGrid x:Name="dataGrid_Car"  Margin="10" Grid.ColumnSpan="2" ItemsSource="{Binding Path=Cars, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" AutoGenerateColumns="False" CanUserAddRows="False">
		<i:Interaction.Triggers>
		  <i:EventTrigger EventName="CellEditEnding">
			<i:InvokeCommandAction Command="{Binding SomeCommand}"/>
		  </i:EventTrigger>
		</i:Interaction.Triggers>
        <DataGrid.Columns>
            <DataGridTextColumn x:Name="Constructor" Header="Constructor"  Width="*" Binding="{Binding _constructor, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
            </DataGridTextColumn>
            <DataGridTextColumn x:Name="Model" Header="Model" Width="*" Binding="{Binding model}">
            </DataGridTextColumn>
            <DataGridTextColumn x:Name="Price" Header="Price" Width="*" Binding="{Binding price}">
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
And add a command to your ViewModel.
If you use mvvmlight you could just create a RelayCommand and do whatever you like with that.
