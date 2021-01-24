    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding People}" Grid.Row="1" HorizontalScrollBarVisibility="Visible" FontSize="30">
        <DataGrid.Columns>
            <DataGridTextColumn Header="FirstNames" Binding="{Binding FirstNames}" />
            <DataGridTextColumn Header="LastName" Binding="{Binding LastName}" />
            <DataGridTextColumn Header="Age" Binding="{Binding Age}" />
            <DataGridTextColumn Header="Address" Binding="{Binding Address}" />
            <DataGridTextColumn Header="PostCode" Binding="{Binding PostCode}" />
            <DataGridTextColumn Header="PhoneNumber" Binding="{Binding PhoneNumber}" />
        </DataGrid.Columns>
    </DataGrid>
