    <Window>
      <Window.DataContext>
        <ViewModel />
      </Window.DataContext>
      <Grid>
        <DataGrid AutoGenerateColumns="False"
                  ItemsSource="{Binding TableXElement}">
          <DataGrid.Columns>
            <DataGridTextColumn Header="Username"
                                Binding="{Binding Path=Elements[Username][0].Value}" />
            <DataGridTextColumn Header="First Name"
                                Binding="{Binding Path=Elements[FirstName][0].Value}" />
            <DataGridTextColumn Header="Last Name"
                                Binding="{Binding Path=Elements[LastName][0].Value}" />
          </DataGrid.Columns>
        </DataGrid>
      <Grid>
    <Window>
