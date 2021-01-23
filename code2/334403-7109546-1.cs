    <sdk:DataGrid Name="dataGrid" ItemsSource="{Binding Data}" AutoGenerateColumns="False"
                  SelectedItem="{Binding SelectedPerson, Mode=TwoWay}" Grid.Row="1">
        <sdk:DataGrid.Columns>
            <sdk:DataGridTextColumn Binding="{Binding Name, Mode=TwoWay}"/>
            <sdk:DataGridTextColumn Binding="{Binding Age, Mode=TwoWay}"/>
        </sdk:DataGrid.Columns>
    </sdk:DataGrid>
