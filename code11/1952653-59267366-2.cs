        <DataGrid Name="DgLogs" Margin="8" AutoGenerateColumns="False" IsReadOnly="True" Initialized="DgLogs_OnInitialized">
            <DataGrid.Resources>
                <myProject:MyHeaderToVisibilityConverter x:Key="MyHeaderToVisibilityConverter"/>
            </DataGrid.Resources>
            <DataGrid.Columns>
                <DataGridTextColumn Header="Line #" Binding="{Binding LineNum}" Visibility="{Binding Path=Header, RelativeSource={RelativeSource Self},  Converter={StaticResource MyHeaderToVisibilityConverter}}"/>
                <DataGridTextColumn Header="Data1" Binding="{Binding Data1}" Visibility="{Binding Path=Header, RelativeSource={RelativeSource Self},  Converter={StaticResource MyHeaderToVisibilityConverter}}"/>
                <DataGridTextColumn Header="Data2" Binding="{Binding Data2}" Visibility="{Binding Path=Header, RelativeSource={RelativeSource Self},  Converter={StaticResource MyHeaderToVisibilityConverter}}"/>
                <DataGridTextColumn Header="Data3" Binding="{Binding Data3}" Visibility="{Binding Path=Header, RelativeSource={RelativeSource Self},  Converter={StaticResource MyHeaderToVisibilityConverter}}"/>
            </DataGrid.Columns>
        </DataGrid>
