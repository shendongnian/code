      <Window.Resources>
        <local:AllNamesProvider x:Key="NamesProvider" />
        <local:NameConverter x:Key="NameConverter" />
      </Window.Resources>
      <Window.DataContext>
        <local:ViewModel />
      </Window.DataContext>
        <Grid>
        <Grid.RowDefinitions>
          <RowDefinition />
          <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <DataGrid Grid.ColumnSpan="2" AutoGenerateColumns="False" ItemsSource="{Binding Persons, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}" >
          <DataGrid.Columns>
            <DataGridTextColumn Header="Id" Binding="{Binding Id}" Width="100"/>
            <DataGridTextColumn Header="Name1" Binding="{Binding Name}" Width="200" />
            <DataGridTemplateColumn Header="Name2" Width="200">
              <DataGridTemplateColumn.CellTemplate>
              <DataTemplate>
                <TextBlock Text="{Binding Name, UpdateSourceTrigger=PropertyChanged}"/>
              </DataTemplate>
              </DataGridTemplateColumn.CellTemplate>
              <DataGridTemplateColumn.CellEditingTemplate>
                <DataTemplate>
                  <ComboBox ItemsSource="{Binding Path=AllNames, Source={StaticResource ResourceKey=NamesProvider}}"                        
                            DisplayMemberPath="LastName"
                            SelectedItem="{Binding Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, Converter={StaticResource NameConverter}}" />
                </DataTemplate>
              </DataGridTemplateColumn.CellEditingTemplate>
    
            </DataGridTemplateColumn>
          </DataGrid.Columns>
        </DataGrid>
        <ComboBox 
          ItemsSource="{StaticResource ResourceKey=NamesProvider}"
          DisplayMemberPath="LastName"
          Grid.Row="1" />
      </Grid>
