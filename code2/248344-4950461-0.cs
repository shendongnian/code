    <sdk:DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Items}" IsReadOnly="False" SelectionMode="Single">
        <sdk:DataGrid.Columns>
            <sdk:DataGridTextColumn Header="Title" Binding="{Binding Title}"/>
            <sdk:DataGridTemplateColumn Header="Link" Width="100">
                <sdk:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding Link, Mode=TwoWay}" Margin="2" 
                                 IsEnabled="False" BorderThickness="0" Background="Transparent"/>
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellTemplate>
                <sdk:DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding Link, Mode=TwoWay}" Margin="2"/>
                    </DataTemplate>
                </sdk:DataGridTemplateColumn.CellEditingTemplate>
            </sdk:DataGridTemplateColumn>
        </sdk:DataGrid.Columns>
    </sdk:DataGrid>
