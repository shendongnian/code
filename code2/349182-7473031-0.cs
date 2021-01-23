    <my:DataGrid ItemsSource="{Binding ElementName=cbPickupDate, Path=SelectedItem.WeekData}"
                 AutoGenerateColumns="False">
        <my:DataGrid.Columns>
            <my:DataGridTextColumn Binding="{Binding Path=ReqID}" Header="Request ID" />
            <my:DataGridTextColumn Binding="{Binding Path=LineID}" Header="Line ID" />
            <my:DataGridTextColumn Binding="{Binding Path=OrderID}" Header="Order ID" />
        </my:DataGrid.Columns>
    </my:DataGrid>
