    <DataGrid Name="MyGrid"  AutoGenerateColumns="False" Loaded="MyGrid_Loaded" Height="250"  >
    <DataGrid.Columns>
        <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
        <DataGridTemplateColumn Header="B1">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Button Content="Start" x:Name="Play" Click="Button_Click" IsEnabled="{Binding IsEnableButton, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="20" Width="80"/>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
        <DataGridTemplateColumn Header="B2">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Button Content="Pause"  x:Name="Pause" Click="Button_Click" IsEnabled="{Binding IsEnableButton, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="20" Width="80"/>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
        <DataGridTemplateColumn Header="B3">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Button Content="Stop"  x:Name="Stop" Click="Button_Click" IsEnabled="{Binding IsEnableButton, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="20" Width="80"/>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
        <DataGridTemplateColumn Header="B4">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Button Content="Finish"  x:Name="Finish" Click="Button_Click" IsEnabled="{Binding IsEnableButton, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Height="20" Width="80"/>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
    </DataGrid.Columns>
