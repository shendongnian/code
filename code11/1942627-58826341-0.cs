    <DataGrid ItemsSource="{Binding Path=idlessTicketList, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"  AutoGenerateColumns="False" >
           <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Mode=TwoWay, Path=ticketCustomer, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Binding="{Binding Mode=TwoWay, Path=ticketText, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Binding="{Binding Mode=TwoWay, Path=ticketTime, UpdateSourceTrigger=PropertyChanged, StringFormat=\{0:n2\}}"/>
           </DataGrid.Columns>
    </Datagrid>
